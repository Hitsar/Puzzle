﻿using TagComponents.Audio;
using UnityEngine;

namespace Assets.Scripts.TagComponents.Audio
{
    public class SoundAudioSource : MonoBehaviour, IAudioSourceTag
    {
        [SerializeField] private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;

        public void Init()
        {
            _audioSource.Play();
            _audioSource.Stop();
        }
    }
}