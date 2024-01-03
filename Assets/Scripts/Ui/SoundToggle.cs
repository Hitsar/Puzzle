using Config;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class SoundToggle : MonoBehaviour, IToggle
    {
        [SerializeField] private Toggle _toggle;
        public Toggle Toggle => _toggle;
        private MetagameMediatorToLogic _metagameMediatorToLogic;
        private SettingsHolder _settingsHolder;
        [Inject]
        public void Construct(MetagameMediatorToLogic metagameMediatorToLogic, SettingsHolder settingsHolder)
        {
            _metagameMediatorToLogic = metagameMediatorToLogic;
            _settingsHolder = settingsHolder;
        }

        private void OnEnable()
        {
            _toggle.isOn = _settingsHolder.IsSoundMuted;
            _toggle.onValueChanged.AddListener(delegate { UpdateLogic(_toggle); });
        }

        public void UpdateLogic(Toggle change)
        {
            _metagameMediatorToLogic.SetSoundVolume(_toggle.isOn);
        }

        public void UpdateToggleVisuals(bool newValue)
        {
            _toggle.isOn = newValue;
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(delegate { UpdateLogic(_toggle); });
        }
    }
}
