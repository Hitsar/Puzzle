using System;
using UnityEngine;
using YG;

namespace Localization
{
    public class Language
    {
        private LanguageTags _currentLanguage;
        public LanguageTags CurrentLanguage => _currentLanguage;

        public void Init()
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