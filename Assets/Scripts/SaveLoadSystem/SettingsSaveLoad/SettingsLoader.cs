using UnityEngine;
using UI;
using Zenject;
using Config;

namespace Saves.SettingsSaveLoad
{
    public class SettingsLoader : MonoBehaviour
    {
        private SettingsHolder _settingsHolder;
        [Inject]
        public void Construct( SettingsHolder settingsHolder)
        {
            _settingsHolder = settingsHolder;
        }

        public void LoadSettings()
        { 
            var settingsData = LocalStorage.LoadSettings();
            if (settingsData.MusicMuted != null && settingsData.VoicesMuted != null)
                _settingsHolder.SetSettings((bool)settingsData.MusicMuted, (bool)settingsData.VoicesMuted);
            Debug.Log($"Settings Loaded. Music: {settingsData.MusicMuted}, Voices: {settingsData.VoicesMuted}");
        }
    }
}