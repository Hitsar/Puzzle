using TMPro;
using UnityEngine;

namespace Shop
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private int _money;
        private int _moneyForWin;
        
        public bool AddMoney(int money)
        {
            if (money <= 0) return false;
            
            _money += money;
            _text.text = _money.ToString();
            return true;
        }

        public void AddMoneyForWin()
        {
            _money += _moneyForWin;
            _text.text = _money.ToString();
        }

        public bool RemoveMoney(int money)
        {
            if (_money - money <= 0 || money <= 0) return false;
            
            _money -= money;
            _text.text = _money.ToString();
            return true;
        }

        public void SetMoneyForWin(int money)
        {
            if (money <= 0) return;
            
            _moneyForWin = money;
            _text.text = _money.ToString();
        }
    }
}