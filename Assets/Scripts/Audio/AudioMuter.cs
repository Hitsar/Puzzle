using Assets.Scripts.TagComponents.Audio;
using TagComponents.Audio;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Audio
{
    public class AudioMuter
    {
        private AudioMixer _audioMixer;
        private MusicAudioSource _musicAudioSource;
        private SoundAudioSource _soundAudioSource;

        [Inject]
        public AudioMuter(AudioMixer audioMixer, MusicAudioSource musicAudioSource, SoundAudioSource soundAudioSource)
        {
            _audioMixer = audioMixer;
            _musicAudioSource = musicAudioSource;
            _soundAudioSource = soundAudioSource;
        }

        public void SetMusicVolume(bool muted)
        {
            _audioMixer.SetFloat("Music", muted ? -80 : 0);
        }
        public void SetSoundVolume(bool muted)
        {
            _audioMixer.SetFloat("Sound", muted ? -80 : 0);
            if (!muted)
                _soundAudioSource.Init();
        }
    }
}