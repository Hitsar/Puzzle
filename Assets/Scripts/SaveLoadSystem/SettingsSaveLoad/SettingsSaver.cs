using Config;
using System;
using UnityEngine;
using Zenject;

namespace Saves.SettingsSaveLoad
{
    public class SettingsSaver : MonoBehaviour
    {
        private SettingsHolder _settingsHolder;
        private DateTime _lastSave;
        [Inject]
        public void Construct(SettingsHolder settingsHolder)
        {
            _settingsHolder = settingsHolder;
        }
        private void Start()
        {
            _lastSave = DateTime.UtcNow;
        }

        public void SaveSettings()
        {
            LocalStorage.SaveSettings(_settingsHolder);
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