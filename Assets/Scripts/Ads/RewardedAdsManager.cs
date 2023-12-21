using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI
using TMPro; // ������ ���� ����������� TextMeshPro
using YG;
using Shop;

namespace AdsManagement
{
    public class RewardedAdsManager : MonoBehaviour
    {
        public static RewardedAdsManager Instance { get; private set; }

        [SerializeField] private int rewardAmount = 100; // ���������� ����� ��� ��������������
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
            Debug.Log("����� ������� � ID: " + adId);
            YandexGame.RewVideoShow(adId);
        }

        private void OnRewardedVideo(int adId)
        {
            if (adId == 0)
            {
                AddCoins(rewardAmount); // ��������� �������� ���������� �����
            }
        }

        private void AddCoins(int amount)
        {
            Debug.Log("��������� ������: " + amount);
            if (wallet != null)
            {
                wallet.AddMoney(amount);
            }
        }
    }
}
