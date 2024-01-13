using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Localization
{
    public class TextLocalizator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        private LocalizationDataSO _localizationData;
        private Language _language;

        [Inject]
        public void Construct(LocalizationDataSO localizationData, Language language)
        {
            _localizationData = localizationData;
            _language = language;
        }

        private void Start()
        {
            _textMeshPro.text = _localizationData.GetLocalizedWinText(_language.CurrentLanguage);
        }
    }
}