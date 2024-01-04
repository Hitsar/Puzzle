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
            Buy();
            OnAdError();
        }

        private void OnAdError()
        {
            YandexGame.RewardVideoEvent -= OnReward;
            YandexGame.ErrorVideoEvent -= OnAdError;
        }

        protected override void AttendBuy() => ShowAd();
    }
}