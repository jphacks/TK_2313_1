using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class CharacterVoiceView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void PlayAudioClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}

