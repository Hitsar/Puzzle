using System;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    public class InternationalImage : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Language _language;

        [Header("Sprites")]
        [SerializeField] private Sprite _englishImage;
        [SerializeField] private Sprite _russianImage;
        [SerializeField] private Sprite _spanishImage;
        [SerializeField] private Sprite _turkishImage;
        [SerializeField] private Sprite _germanImage;

        private const string UNKNOWN_LANGUAGE_ERROR = "Unknown language";

        private void Start()
        {
            TryGetComponent(out Image image);
            if (_language.CurrentLanguage == LanguageTags.en) image.sprite = _englishImage;
            else if (_language.CurrentLanguage == LanguageTags.ru) image.sprite = _russianImage;
            else if (_language.CurrentLanguage == LanguageTags.es) image.sprite = _spanishImage;
            else if (_language.CurrentLanguage == LanguageTags.tr) image.sprite = _turkishImage;
            else if (_language.CurrentLanguage == LanguageTags.de) image.sprite = _germanImage;
            else throw new InvalidOperationException(UNKNOWN_LANGUAGE_ERROR);
        }
    }
}