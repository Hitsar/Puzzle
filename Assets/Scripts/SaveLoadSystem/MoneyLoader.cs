using Shop;
using Zenject;

namespace SaveLoadSystem
{
    public class MoneyLoader
    {
        private Wallet _wallet;
        private LocalStorage _localStorage;
        [Inject]
        public MoneyLoader(Wallet wallet, LocalStorage localStorage)
        {
            _wallet = wallet;
            _localStorage = localStorage;
        }

        public void LoadWallet()
        {
            int moneyValue = _localStorage.GetMoneyValue();
            _wallet.Import(moneyValue);
        }
    }
}