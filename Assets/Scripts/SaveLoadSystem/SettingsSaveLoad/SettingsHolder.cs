using Audio;
using UnityEngine;
using Zenject;

namespace Config
{
    public class SettingsHolder : MonoBehaviour
    {
        private AudioMuter _audioMuter;
        private static bool _musicMuted;
        private static bool _soundMuted;
        public bool IsMusicMuted => _musicMuted;
        public bool IsSoundMuted => _soundMuted;
        [Inject]
        public void Construct(AudioMuter audioMuter)
        {
            _audioMuter = audioMuter;
        }

        public void SetSettings(bool musicMuted, bool soundMuted)
        {
            Debug.Log("Set settings" + musicMuted + soundMuted);
            _musicMuted = musicMuted;
            _soundMuted = soundMuted;
            _audioMuter.SetMusicVolume(musicMuted);
            _audioMuter.SetSoundVolume(soundMuted);
        }

        public void SetMusicMuted(bool newValue)
        {
            _musicMuted = newValue;
            _audioMuter.SetMusicVolume(newValue);
        }

        public void SetSoundMuted(bool newValue) 
        {
            _soundMuted = newValue;
            _audioMuter.SetSoundVolume(newValue);
        }
    }
}