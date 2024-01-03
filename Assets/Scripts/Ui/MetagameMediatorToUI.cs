using UnityEngine;
using Zenject;

namespace UI
{
    public class MetagameMediatorToUI : MonoBehaviour
    {
        private SettingsPanelAnimator _settingsPanelAnimator;
        private MusicToggle _musicToggle;
        private SoundToggle _soundToggle;

        [Inject]
        public void Construct(SettingsPanelAnimator settingsPanelAnimator, MusicToggle musicToggle, SoundToggle soundToggle)
        {
            _settingsPanelAnimator = settingsPanelAnimator;
            _musicToggle = musicToggle;
            _soundToggle = soundToggle;
        }

        public void ShowSettingsPanel() => _settingsPanelAnimator.ShowPanel();
        public void HideSettingsPanel() => _settingsPanelAnimator.HidePanel();
        public void UpdateMusicToggleVisuals(bool newValue) => _musicToggle.UpdateToggleVisuals(newValue);
        public void UpdateSoundToggleVisuals(bool newValue) => _soundToggle.UpdateToggleVisuals(newValue);
    }
}

