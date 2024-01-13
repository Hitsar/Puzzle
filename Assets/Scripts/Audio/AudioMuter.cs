using Audio;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Audio
{
    public class AudioMuter
    {
        private AudioMixer _audioMixer;
        private MusicAudioSource _musicAudioSource;

        [Inject]
        public AudioMuter(AudioMixer audioMixer, MusicAudioSource musicAudioSource)
        {
            _audioMixer = audioMixer;
            _musicAudioSource = musicAudioSource;
        }

        public void SetMusicVolume(bool muted)
        {
            _audioMixer.SetFloat("Music", muted ? -80 : 0);
        }
        public void SetSoundVolume(bool muted)
        {
            _audioMixer.SetFloat("Sound", muted ? -80 : 0);
        }
    }
}