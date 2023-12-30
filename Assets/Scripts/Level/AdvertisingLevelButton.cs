using YG;

namespace Level
{
    public class AdvertisingLevelButton : PurchasedLevelButton
    {
        private void ShowAd()
        {
            YandexGame.RewVideoShow(0);
            YandexGame.RewardVideoEvent += OnReward;
            YandexGame.ErrorVideoEvent += OnAdError;
        }

        private void OnReward(int obj)
        {
            EndBuy();
            OnAdError();
        }

        private void OnAdError()
        {
            YandexGame.RewardVideoEvent -= OnReward;
            YandexGame.ErrorVideoEvent -= OnAdError;
        }

        protected override void Buy() => ShowAd();
    }
}