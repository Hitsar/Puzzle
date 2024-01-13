using UnityEngine;
using Zenject;
using Config;

namespace SaveLoadSystem
{
    public class SettingsLoader : MonoBehaviour
    {
        private SettingsHolder _settingsHolder;
        private LocalStorage _localStorage;
        [Inject]
        public void Construct( SettingsHolder settingsHolder, LocalStorage localStorage)
        {
            _settingsHolder = settingsHolder;
            _localStorage = localStorage;
        }

        public void LoadSettings()
        { 
            var settingsData = _localStorage.LoadSettings();
            if (settingsData.MusicMuted != null && settingsData.VoicesMuted != null)
                _settingsHolder.SetMusicMuted((bool)settingsData.MusicMuted);
            if (settingsData.VoicesMuted != null)
                _settingsHolder.SetSoundMuted((bool)settingsData.VoicesMuted);
            //Debug.Log($"Settings Loaded. Music: {settingsData.MusicMuted}, Voices: {settingsData.VoicesMuted}");
        }
    }
}