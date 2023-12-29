using UnityEngine;
using UnityEngine.UI;

namespace Saves.SettingsSaveLoad
{
    public class SettingsLoader : MonoBehaviour
    {
        [SerializeField] private Toggle MusicToggle;
        [SerializeField] private Toggle VoiceToggle;
        
        private void Awake()
        {
            var settingsData = LocalStorage.LoadSettings();
            if (settingsData.MusicMuted != null)
                MusicToggle.isOn = !(bool)settingsData.MusicMuted;
            if (settingsData.VoicesMuted != null)
                VoiceToggle.isOn = !(bool)settingsData.VoicesMuted;
            Debug.Log($"Settings Loaded. Music: {settingsData.MusicMuted}, Voices: {settingsData.VoicesMuted}");
        }
    }
}