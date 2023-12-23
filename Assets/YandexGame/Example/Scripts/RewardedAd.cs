using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

namespace YG.Example
{
    public class RewardedAd : MonoBehaviour
    {
        [SerializeField] int AdID;
        [SerializeField] TMP_Text textMoney;

        int moneyCount = 100;

        void Awake()
        {
            AdMoney(0);
        }

        public void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
        public void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

        void Rewarded(int id)
        {
            if (id == AdID)
                AdMoney(1);
        }

        void AdMoney(int count)
        {
            moneyCount += count;
            textMoney.text = "" + moneyCount;
        }

        // Метод для вызова видео рекламы
        void ExampleOpenRewardAd(int id)
        {
            // Вызываем метод открытия видео рекламы
            YandexGame.RewVideoShow(id);
        }
    }
}

