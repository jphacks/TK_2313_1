using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void RunMotionAction(string actionName)
        {
            switch (actionName)
            {
                case "byebye":
                    _animator.SetInteger("State", 1);
                    break;
            }
        }
    }
}

