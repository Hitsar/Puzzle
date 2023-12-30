using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Shop
{
    public class CoinDoubler : MonoBehaviour
    {
        private Wallet _wallet;
        private Button _button;
        
        private void Start()
        {
            _wallet = FindAnyObjectByType<Wallet>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(ShowAd);
        }

        private void OnEnable() { if (_button != null) _button.interactable = true; }

        private void ShowAd()
        {
            YandexGame.RewVideoShow(0);
            YandexGame.RewardVideoEvent += OnReward;
            YandexGame.ErrorVideoEvent += OnAdError;
        }

        private void OnReward(int obj)
        {
            _button.interactable = false;
            
            _wallet.AddMoneyForWin();
            OnAdError();
        }

        private void OnAdError()
        {
            YandexGame.RewardVideoEvent -= OnReward;
            YandexGame.ErrorVideoEvent -= OnAdError;
        }
    }
}