using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace View
{
    public class AnchorView : MonoBehaviour
    {
        public string Uuid { get; set; }
        public bool binded { get; set; }

        private void Start()
        {
            binded = false;
        }

        void Update()
        {
            if (binded)
            {
                Debug.Log("test test test");
                float distance = 999;
                try
                {
                     distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                        new Vector2(UserHandView.Instance.transform.position.x,
                            UserHandView.Instance.transform.position.z));
                }
                catch (Exception e)
                {
                    Debug.Log($"[Anchor error] {e}");
                }
                Debug.Log($"distance {distance}");
                if (distance < 0.75f)
                {
                    Debug.Log("test 8");
                    // transform.GetChild(0).gameObject.SetActive(true);
                    ApiController.Instance.SendNearAnchorEvent(Uuid);
                }
            }
        }
    }
}

