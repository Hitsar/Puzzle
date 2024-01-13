using UnityEngine;

namespace Audio
{
    public class MusicAudioSource : MonoBehaviour, IAudioSourceTag
    {
        [SerializeField] private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
        public void PlayMusic()
        {
            /*if (!_started)
            {
                _audioSource.Play();
                _started = true;
            }*/
        }
    }
}