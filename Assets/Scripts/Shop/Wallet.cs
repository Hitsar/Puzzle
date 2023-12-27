using Saves;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class Wallet : MonoBehaviour, ISaveableMoney
    {
        [SerializeField] private TMP_Text _textMoney;
        [SerializeField] private TMP_Text _textMoneyForWin;
        
        private int _money;
        private int _moneyForWin;

        private static Wallet _instance;
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }

        public void AddMoneyForWin()
        {
            _money += _moneyForWin;
            _textMoney.text = _money.ToString();          
        }

        public bool RemoveMoney(int money)
        {
            if (_money - money < 0 || money < 0) return false;
            
            _money -= money;
            _textMoney.text = _money.ToString();
            
            return true;
        }

        public void UpdateMoney() => _textMoney.text = _money.ToString();
            
        public void SetMoneyForWin(int money)
        {
            if (money < 0) return;
            
            _moneyForWin = money;
            _textMoneyForWin.text = _moneyForWin.ToString();
        }

        public void Import(ProgressWallet progressWallet)
        {
            _money = progressWallet.MoneyCount;
        }

        public ProgressWallet Export()
        {
            return new ProgressWallet
            {
                MoneyCount = _money
            };
        }
    }
}