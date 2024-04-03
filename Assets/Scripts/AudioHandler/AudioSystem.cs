using System;
using System.Collections;
using UnityEngine;

namespace AudioHandler
{
    public class AudioSystem : MonoBehaviour
    {
        public static AudioSystem GetInstance { get; private set; }
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            if (GetInstance == null)
            {
                GetInstance = this;
            }
            else if (GetInstance != null && GetInstance != this)
            {
                Destroy(this);
            }
            
        }

        public void PlayOnce(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void PlayOnDela(AudioClip clip, float delayTime)
        {
            audioSource.clip = clip;
            audioSource.PlayDelayed(delayTime);
        }

        public void Play(bool state)
        {
            audioSource.mute = state;
        }

        public void ChangeAudioVolume(float volume)
        {
            audioSource.volume = volume;
        }

        private IEnumerator EPlayDelay(float delayTime,AudioClip clip)
        {
            yield return new WaitForSeconds(delayTime);
            audioSource.PlayOneShot(clip);
        }

    }
}

