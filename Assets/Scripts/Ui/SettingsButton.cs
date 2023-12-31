using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private MetagameMediatorToUI _metagameMediatorToUI;

        [Inject]
        public void Construct(MetagameMediatorToUI metagameMediatorToUI)
        {
            _metagameMediatorToUI = metagameMediatorToUI;
        }

        private void OnEnable() => _button.onClick.AddListener(delegate { OnClick(); });
        private void OnClick() => _metagameMediatorToUI.ShowSettingsPanel();
        private void OnDisable() =>_button.onClick.RemoveListener(delegate { OnClick(); });
    }
}

