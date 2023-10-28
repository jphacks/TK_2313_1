using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class UserHandView : MonoBehaviour
    {
        public static UserHandView Instance { get; private set; }

        void Start()
        {
            Instance = this;
        }
    }
}

