using UnityEngine;

namespace Audio
{
    public class WinAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
    }
}

