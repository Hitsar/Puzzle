using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI
using TMPro; // ������ ���� ����������� TextMeshPro
using YG;
using Shop;

namespace AdsManagement
{
    public class RewardedAdsManager : MonoBehaviour
    {
        [SerializeField] private Wallet wallet;

        private void OnEnable() => YandexGame.RewardVideoEvent += OnRewardedVideo;

        private void OnDisable() => YandexGame.RewardVideoEvent -= OnRewardedVideo;

        public void ShowRewardedAd(int adId)
        {
            Debug.Log("����� ������� � ID: " + adId);
            YandexGame.RewVideoShow(adId);
        }

        private void OnRewardedVideo(int adId) { if (adId == 0) AddCoins(); }

        private void AddCoins()
        {
            Debug.Log("��������� ������");
            if (wallet != null) wallet.AddMoneyForWin();
        }
    }
}