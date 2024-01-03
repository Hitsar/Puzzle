using UnityEngine;

namespace TagComponents.Audio
{
    public class MusicAudioSource : MonoBehaviour, IAudioSourceTag
    {
        [SerializeField] private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
    }
}