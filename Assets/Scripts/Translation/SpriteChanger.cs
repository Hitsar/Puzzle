using UnityEngine;
using UnityEngine.UI; 

namespace YG
{
    public class SpriteChanger : MonoBehaviour
    {
        [SerializeField] private Sprite[] languageSprites;
        [SerializeField] private Image imageComponent;

        private void OnEnable() => YandexGame.SwitchLangEvent += UpdateLanguageSprite;

        private void OnDisable() => YandexGame.SwitchLangEvent -= UpdateLanguageSprite;

        private void UpdateLanguageSprite(string newLanguage)
        {
            int languageIndex = -1;

            switch (newLanguage)
            {
                case "ru":
                    languageIndex = 0;
                    break;
                case "en":
                    languageIndex = 1;
                    break;
                case "tr":
                    languageIndex = 2;
                    break;
                case "de":
                    languageIndex = 3;
                    break;
                case "es":
                    languageIndex = 4;
                    break;
                default:
                    Debug.LogError("Неизвестный язык: " + newLanguage);
                    break;
            }

            if (languageIndex >= 0 && languageIndex < languageSprites.Length)
            {
                imageComponent.sprite = languageSprites[languageIndex];
            }
            else
            {
                Debug.LogError("Спрайт для языка " + newLanguage + " не найден");
            }
        }
    }
}
