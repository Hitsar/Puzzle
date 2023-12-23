using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ��������� ������������ ���� ��� ������ � UI

namespace YG
{
    public class SpriteChanger : MonoBehaviour
    {
        [SerializeField] private List<Sprite> languageSprites; // ������� ��� ������ ������
        [SerializeField] private Image imageComponent; // ���������� ��������� Image ��� ����������� �������

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
                    Debug.LogError("����������� ����: " + newLanguage);
                    break;
            }

            if (languageIndex >= 0 && languageIndex < languageSprites.Count)
            {
                imageComponent.sprite = languageSprites[languageIndex];
            }
            else
            {
                Debug.LogError("������ ��� ����� " + newLanguage + " �� ������");
            }
        }
    }
}
