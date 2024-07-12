using UnityEngine;
using UnityEngine.Audio;

namespace Code.AudioSystem.Controller
{
    public class AudioPlayer : MonoBehaviour
    {
        public AudioSource audioSource;

        public void PlaySound(AudioClip clip, ulong delay =  0 )
        {
            audioSource.clip = clip;
            audioSource.Play(delay);
        }

        public void StopSound()
        {
            audioSource.Stop();
        }


    }
}