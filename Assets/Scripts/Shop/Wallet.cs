using TMPro;
using UnityEngine;
using YG;

namespace Shop
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMoney;
        [SerializeField] private TMP_Text _textMoneyForWin;
        
        private int _money;
        private int _moneyForWin;

        private static Wallet _instance;
        
        private void Awake()
        {
            YandexGame.LoadCloud();
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            _instance = this;
            _money = YandexGame.savesData.money;
        }

        public void AddMoneyForWin()
        {
            _money += _moneyForWin;
            _textMoney.text = _money.ToString();
            
            YandexGame.savesData.money = _money;
            YandexGame.SaveCloud();
        }

        public bool RemoveMoney(int money)
        {
            if (_money - money < 0 || money < 0) return false;
            
            _money -= money;
            _textMoney.text = _money.ToString();
            
            YandexGame.savesData.money = _money;
            YandexGame.SaveCloud();
            return true;
        }

        public void SetMoneyForWin(int money)
        {
            if (money < 0) return;
            
            _moneyForWin = money;
            _textMoneyForWin.text = _moneyForWin.ToString();
        }
    }
}