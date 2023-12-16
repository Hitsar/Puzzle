using UnityEngine;

namespace Shop
{
    public class Wallet : MonoBehaviour
    {
        private int _money;
        private int _moneyForWin;
        
        public bool AddMoney(int money)
        {
            if (money <= 0) return false;
            
            _money += money;
            return true;
        }

        public void AddMoneyForWin() => _money += _moneyForWin;

        public bool RemoveMoney(int money)
        {
            if (_money - money <= 0 || money <= 0) return false;
            
            _money -= money;
            return true;
        }

        public void SetMoneyForWin(int money) { if (money > 0) _moneyForWin = money; }
    }
}