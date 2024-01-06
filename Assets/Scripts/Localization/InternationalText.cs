using System;
using TMPro;
using UnityEngine;

namespace Localization
{
    public class InternationalText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Language _language;

        [Header("Strings")]
        [SerializeField] private string _englishText;
        [SerializeField] private string _russianText;
        [SerializeField] private string _spanishText;
        [SerializeField] private string _turkishText;
        [SerializeField] private string _germanText;

        private const string UNKNOWN_LANGUAGE_ERROR = "Unknown language";

        private void Start()
        {
            TryGetComponent(out TextMeshProUGUI textMesh);
            if (_language.CurrentLanguage == LanguageTags.en) textMesh.text = _englishText;
            else if (_language.CurrentLanguage == LanguageTags.ru) textMesh.text = _russianText;
            else if (_language.CurrentLanguage == LanguageTags.es) textMesh.text = _spanishText;
            else if (_language.CurrentLanguage == LanguageTags.tr) textMesh.text = _turkishText;
            else if (_language.CurrentLanguage == LanguageTags.de) textMesh.text = _germanText;
            else throw new InvalidOperationException(UNKNOWN_LANGUAGE_ERROR);
        }
    }
}