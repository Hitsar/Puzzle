using System;
using UnityEngine;

namespace Saves.SettingsSaveLoad
{
    public class SettingsSaver : MonoBehaviour
    {
        [SerializeField] private SettingsValues _settings;

        private DateTime _lastSave;
        private void Start()
        {
            _lastSave = DateTime.UtcNow;
            _settings.OnMusicMutedChanged += SaveSettings;
            _settings.OnVoicesMutedChanged += SaveSettings;
        }

        public void SaveSettings()
        {
            SettingsData settingsData = new SettingsData
            {
                MusicMuted = !_settings.IsMusicUnMuted,
                VoicesMuted = !_settings.IsVoicesUnMuted
            };
            LocalStorage.SaveSettings(settingsData);
            Debug.Log("Settings Saved");
        }

        private void Update()
        {
            if (_lastSave.AddSeconds(13) < DateTime.UtcNow)
            {
                SaveSettings();
                _lastSave = DateTime.UtcNow;
            }
        }

        private void OnApplicationQuit()
        {
            SaveSettings();
        }

        private void OnDestroy()
        {
            _settings.OnMusicMutedChanged -= SaveSettings;
            _settings.OnVoicesMutedChanged -= SaveSettings;
        }
    }
}