using System;
using UnityEngine;
using YG;

namespace Localization
{
    public class Language : MonoBehaviour
    {
        private LanguageTags _currentLanguage;
        public LanguageTags CurrentLanguage => _currentLanguage;

        private void Awake()
        {
            _currentLanguage = (LanguageTags)Enum.Parse(typeof(LanguageTags), YandexGame.EnvironmentData.language, true);
        }
    }

    public enum LanguageTags
    {
        en,
        ru,
        es,
        tr,
        de
    }
}