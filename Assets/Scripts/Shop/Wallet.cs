using SaveLoadSystem;
using TMPro;
using UI;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class Wallet :  ISaveableMoney
    {
        public int Money { get; private set; }
        private MoneyDataSO _moneyData;
        private MoneyDisplay _moneyDisplay;
        private int _levelReward;
        public int LevelReward => _levelReward;
        

        [Inject]
        public Wallet(MoneyDisplay moneyDisplay, MoneyDataSO moneyDataSO)
        {
            _moneyDisplay = moneyDisplay;
            _moneyData = moneyDataSO;
        }

        public void AddMoneyForWin()
        {
            Money += _levelReward;
            _moneyDisplay.UpdateMoneyValue(Money);
        }

        public bool RemoveMoney(int money)
        {
            if (Money - money < 0 || money < 0) return false;
            
            Money -= money;
            _moneyDisplay.UpdateMoneyValue(Money);
            return true;
        }
            
        public void SetMoneyForWin(int levelNumber)
        {   
            _levelReward = _moneyData.GetReward(levelNumber);
        }

        public void Import(int savedMoneyValue)
        {
            Money = savedMoneyValue;
            _moneyDisplay.UpdateMoneyValue(Money);
        }

        public ProgressWallet Export()
        {
            return new ProgressWallet
            {
                MoneyCount = Money
            };
        }
    }
}