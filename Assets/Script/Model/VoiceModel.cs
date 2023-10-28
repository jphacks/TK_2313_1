using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class ReceiveVoice
    {
        public string Kind { get; set; }
        public string Text { get; set; }
        public string Base64 { get; set; }
        public string Action { get; set; }
    }

    public class SendVoiceEvent
    {
        public string Kind { get; set; }
        public string Base64 { get; set; }
    }

}