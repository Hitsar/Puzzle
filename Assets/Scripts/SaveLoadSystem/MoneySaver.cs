using Shop;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class MoneySaver
    {
        private Wallet _wallet;

        [Inject]
        public void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }

        public void SaveMoney()
        {
            LocalStorage.SaveMoney(_wallet.Money);
        }
    }
}