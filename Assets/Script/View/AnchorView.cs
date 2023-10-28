using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace View
{
    public class AnchorView : MonoBehaviour
    {
        public string Uuid { get; set; }
        
        void Update()
        {
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(UserHandView.Instance.transform.position.x, UserHandView.Instance.transform.position.z));
            if (distance < 0.75f)
            {
                ApiController.Instance.SendNearAnchorEvent(Uuid);
            }
        }
    }
}

