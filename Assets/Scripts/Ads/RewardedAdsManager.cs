using UnityEngine;
using UnityEngine.UI; // Для работы с UI
using TMPro; // Только если используете TextMeshPro
using YG;
using Shop;

namespace AdsManagement
{
    public class RewardedAdsManager : MonoBehaviour
    {
        public static RewardedAdsManager Instance { get; private set; }

        [SerializeField] private int rewardAmount = 100; // Количество монет для вознаграждения
        [SerializeField] private Wallet wallet;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += OnRewardedVideo;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= OnRewardedVideo;
        }

        public void ShowRewardedAd(int adId)
        {
            Debug.Log("Показ рекламы с ID: " + adId);
            YandexGame.RewVideoShow(adId);
        }

        private void OnRewardedVideo(int adId)
        {
            if (adId == 0)
            {
                AddCoins(rewardAmount); // Добавляем заданное количество монет
            }
        }

        private void AddCoins(int amount)
        {
            Debug.Log("Добавляем монеты: " + amount);
            if (wallet != null)
            {
                wallet.AddMoney(amount);
            }
        }
    }
}
