using Shop;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class MoneyLoader
    {
        private Wallet _wallet;
        [Inject]
        public MoneyLoader(Wallet wallet)
        {
            _wallet = wallet;
        }

        public void LoadWallet()
        {
            int moneyValue = LocalStorage.GetMoneyValue();
            _wallet.Import(moneyValue);
        }
    }
}