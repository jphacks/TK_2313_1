using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using NativeWebSocket;

namespace Controller
{
    public class ApiController : MonoBehaviour
    {
        [SerializeField] private string _wsEndPoint;

        private WebSocket _webSocket;
        // Start is called before the first frame update
        void Start()
        {
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
            _webSocket.OnMessage += _ => { };
            await _webSocket.Connect();
        }

        private void OnMessage(byte[] bytes)
        {
            string json = System.Text.Encoding.UTF8.GetString(bytes);

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
    }
}

