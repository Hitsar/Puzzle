using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    public class InternationalImage : MonoBehaviour
    {
        [SerializeField] private Sprite _englishImage;
        [SerializeField] private Sprite _russianImage;
        [SerializeField] private Sprite _spanishImage;
        [SerializeField] private Sprite _turkishImage;
        [SerializeField] private Sprite _germanImage;

        private const string UNKNOWN_LANGUAGE_ERROR = "Unknown language";

        private void Start()
        {
            TryGetComponent(out Image image);
            if (Language.CurrentLanguage == LanguageTags.en) image.sprite = _englishImage;
            else if (Language.CurrentLanguage == LanguageTags.ru) image.sprite = _russianImage;
            else if (Language.CurrentLanguage == LanguageTags.es) image.sprite = _spanishImage;
            else if (Language.CurrentLanguage == LanguageTags.tr) image.sprite = _turkishImage;
            else if (Language.CurrentLanguage == LanguageTags.de) image.sprite = _germanImage;
            else throw new InvalidOperationException(UNKNOWN_LANGUAGE_ERROR);
        }
    }
}