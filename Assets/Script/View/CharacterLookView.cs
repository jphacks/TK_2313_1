using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class CharacterLookView : MonoBehaviour
    {
        [SerializeField] private Transform _ovrCameraRig;

        [SerializeField] private Transform _characterRoot;

        [SerializeField] private Transform _characterHead;
        // Start is called before the first frame update
        void Start()
        {
            var playerPos = _ovrCameraRig.position;
            playerPos.y = 0;
            _characterRoot.LookAt(playerPos);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            _characterHead.LookAt(_ovrCameraRig.position);
        }
    }
}

