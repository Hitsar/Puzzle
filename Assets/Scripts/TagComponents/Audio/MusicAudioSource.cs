﻿using Audio;
using Config;
using UnityEngine;
using Zenject;

namespace TagComponents.Audio
{
    public class MusicAudioSource : MonoBehaviour, IAudioSourceTag
    {
        [SerializeField] private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
        private bool _started = false;
        public void PlayMusic()
        {
            if (!_started)
            {
                _audioSource.Play();
                _started = true;
            }
        }
    }
}