using Config;
using System;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem.SettingsSaveLoad
{
    public class SettingsSaver : MonoBehaviour
    {
        private SettingsHolder _settingsHolder;
        private LocalStorage _localStorage;
        private DateTime _lastSave;
        [Inject]
        public void Construct(SettingsHolder settingsHolder, LocalStorage localStorage)
        {
            _settingsHolder = settingsHolder;
            _localStorage = localStorage;
        }
        private void Start()
        {
            _lastSave = DateTime.UtcNow;
        }

        public void SaveSettings()
        {
            _localStorage.SaveSettings(_settingsHolder);
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

        private void OnApplicationFocus(bool focus)
        {
            Debug.Log("On application focus");
            if (!focus)
                SaveSettings();
        }
    }
}