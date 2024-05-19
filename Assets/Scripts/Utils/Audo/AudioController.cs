using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Utils.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : SerializedMonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        
        public Dictionary<string, AudioClip> audios;

        public void Play(string name)
        {
            if (audioSource == null) return;

            if (audios.ContainsKey(name) == false) return;

            audioSource.clip = audios[name];
            audioSource.Play();
        }

        public void Stop()
        {
            if (audioSource == null) return;

            audioSource.Stop();
        }
    }
    
}

