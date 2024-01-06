using UnityEngine;

namespace Audio
{
    public class AudioInPlace : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
    }
}

