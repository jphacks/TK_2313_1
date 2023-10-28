using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    public class MicController : MonoBehaviour
    {
        public static MicController Instance { get; private set; }
        private AudioClip _recordedClip;
        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            //StartMicRec();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public async void StartMicRec()
        {
            string micDevice = Microphone.devices[0];
            // 10秒間の録音を開始
            _recordedClip = Microphone.Start(micDevice, true, 5, 44100);

            await UniTask.WaitForSeconds(5f);
            Microphone.End(null);
            ApiController.Instance.SendVoiceWav(_recordedClip);
        }
    }
}

