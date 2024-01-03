using Audio;
using Config;
using UnityEngine;
using Zenject;

namespace UI
{
    public class MetagameMediatorToLogic : MonoBehaviour
    {
        private SettingsHolder _settingsHolder;
        [Inject]
        public void Construct(AudioMuter audioMuter, SettingsHolder settingsHolder)
        {
            _settingsHolder = settingsHolder;
        }

        public void SetMusicVolume(bool muted) => _settingsHolder.SetMusicMuted(muted);
        public void SetSoundVolume(bool muted) => _settingsHolder.SetSoundMuted(muted);
    }
}

