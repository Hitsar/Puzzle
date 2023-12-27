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

        public void ShowRewardedAd(int adId)
        {
            Debug.Log("����� ������� � ID: " + adId);
        }

        private void OnRewardedVideo(int adId) { if (adId == 0) AddCoins(); }

        private void AddCoins()
        {
            Debug.Log("��������� ������");
            wallet.AddMoneyForWin();
        }
    }
}
