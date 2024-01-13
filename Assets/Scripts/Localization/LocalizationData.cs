using UnityEngine;

namespace Localization
{
    [System.Serializable]
    public class LocalizationData
    {
        [SerializeField] private LanguageTags _language;
        [SerializeField] private Sprite _winSprite;
        [SerializeField] private string _winText;

        public LanguageTags Language => _language;
        public Sprite WinSprite => _winSprite;
        public string WinText => _winText;
    }
}