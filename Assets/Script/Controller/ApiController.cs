using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using UnityEngine;
using NativeWebSocket;
using Model;
using System.Text.Json;
using System.Threading;
using View;

namespace Controller
{
    public class ApiController : MonoBehaviour
    {
        [SerializeField] private CharacterVoiceView _characterVoiceView;
        public static ApiController Instance { get; private set; }
        [SerializeField] private string _wsEndPoint;

        private JsonSerializerOptions _jsonOption = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        private WebSocket _webSocket;
        
        private SynchronizationContext _mainThread;
        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            _mainThread = SynchronizationContext.Current;
            ConnectWebSocket();
        }

        private async Task ConnectWebSocket()
        {
            _webSocket = new(_wsEndPoint);
            _webSocket.OnError += e =>
            {
                Debug.LogError(e.ToString());
            };
            _webSocket.OnClose += e =>
            {
                Debug.Log(e.ToString());
            };
            _webSocket.OnMessage += OnMessage;
            await _webSocket.Connect();
        }

        private void OnMessage(byte[] bytes)
        {
            string json = System.Text.Encoding.UTF8.GetString(bytes);
            WebSocketDataBase dataBase = JsonSerializer.Deserialize<WebSocketDataBase>(json, _jsonOption);
            switch (dataBase.Kind)
            {
                case "receive_wav":
                    ReceiveVoice rv = JsonSerializer.Deserialize<ReceiveVoice>(json, _jsonOption);
                    Debug.Log(json);
                    Debug.Log(rv.Base64);
                    var wavBytes = Convert.FromBase64String(rv.Base64);
                    AudioClip clip = AudioClipConverter.CreateAudioClip(wavBytes, 1, 24000, 16, "voice-" + (UnityEngine.Random.Range(0,100)).ToString());
                    //キャラクターを喋らせる
                    _mainThread.Post(_ =>
                    {
                        _characterVoiceView.PlayAudioClip(clip);
                        
                    }, null);
                    break;
                default:
                    throw new Exception("想定されていないkindのデータが送られてきました");
            }
        }

        // Update is called once per frame
        void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            _webSocket.DispatchMessageQueue();
#endif
        }
        private async void OnApplicationQuit()
        {
            await _webSocket.Close();
        }

        public async Task SendVoiceWav(AudioClip clip)
        {
            var base64 = Convert.ToBase64String(AudioClipConverter.ToWavBinary(clip));
            SendVoiceEvent sendVoiceEvent = new()
            {
                Kind = "send_wav",
                Base64 = base64
            };
            var json = JsonSerializer.Serialize(sendVoiceEvent, _jsonOption);
            await _webSocket.SendText(json);
        }

        public async Task SendNearAnchorEvent(string targetUuid)
        {
            NearAnchorEvent e = new()
            {
                Kind = "event",
                Event = "near_anchor",
                Target = targetUuid
            };
            var json = JsonSerializer.Serialize(e, _jsonOption);
        }
    }
}

