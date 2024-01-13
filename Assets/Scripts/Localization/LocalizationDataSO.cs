using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LocalizationData", order = 4)]
    public class LocalizationDataSO : ScriptableObject
    {
        [SerializeField] private List<LocalizationData> _localizationData;

        public Sprite GetLocalizedWinSprite(LanguageTags language) => GetLocalizationData(language).WinSprite;

        public string GetLocalizedWinText(LanguageTags language) => GetLocalizationData(language).WinText;

        private LocalizationData GetLocalizationData(LanguageTags language) => _localizationData.FirstOrDefault(element => element.Language == language);
    }
}

