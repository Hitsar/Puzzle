using UnityEngine;
using UnityEngine.UI; // Для работы с UI
using TMPro; // Только если используете TextMeshPro
using YG;
using Shop;

namespace AdsManagement
{
    public class RewardedAdsManager : MonoBehaviour
    {
        [SerializeField] private Wallet wallet;

        public void ShowRewardedAd(int adId)
        {
            Debug.Log("Показ рекламы с ID: " + adId);
        }

        private void OnRewardedVideo(int adId) { if (adId == 0) AddCoins(); }

        private void AddCoins()
        {
            Debug.Log("Добавляем монеты");
            wallet.AddMoneyForWin();
        }
    }
}
