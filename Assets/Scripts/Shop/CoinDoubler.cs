using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Shop
{
    public class CoinDoubler : MonoBehaviour
    {
        private Wallet _wallet;
        private Button _button;

        [Inject]
        public void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }

        private void Start()
        {
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