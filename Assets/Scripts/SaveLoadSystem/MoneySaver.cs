using Shop;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class MoneySaver
    {
        private Wallet _wallet;
        private LocalStorage _localStorage;

        [Inject]
        public void Construct(Wallet wallet, LocalStorage localStorage)
        {
            _wallet = wallet;
            _localStorage = localStorage;
        }

        public void SaveMoney()
        {
            _localStorage.SaveMoney(_wallet.Money);
        }
    }
}