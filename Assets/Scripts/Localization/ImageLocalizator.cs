using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Localization
{
    public class ImageLocalizator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image _image;
        private LocalizationDataSO _localizationData;
        private Language _language;

        [Inject]
        public void Construct(LocalizationDataSO localizationDataSO, Language language)
        {
            _localizationData = localizationDataSO;
            _language = language;
        }

        private void Start()
        {
            _image.sprite = _localizationData.GetLocalizedWinSprite(_language.CurrentLanguage);
        }
    }
}