using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Добавляем пространство имен для работы с UI

namespace YG
{
    public class SpriteChanger : MonoBehaviour
    {
        [SerializeField] private List<Sprite> languageSprites; // Спрайты для разных языков
        [SerializeField] private Image imageComponent; // Используем компонент Image для отображения спрайта

        private void OnEnable()
        {
            LanguageManager.OnLanguageChanged += UpdateLanguageSprite;
        }

        private void OnDisable()
        {
            LanguageManager.OnLanguageChanged -= UpdateLanguageSprite;
        }

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

            if (languageIndex >= 0 && languageIndex < languageSprites.Count)
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
