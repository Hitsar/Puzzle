using Saves;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class Wallet : MonoBehaviour, ISaveableMoney
    {
        public int Money { get; private set; }

        [SerializeField] private TMP_Text _textMoney;
        [SerializeField] private TMP_Text _textMoneyForWin;
        
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
            Money += _moneyForWin;
            _textMoney.text = Money.ToString();          
        }

        public bool RemoveMoney(int money)
        {
            if (Money - money < 0 || money < 0) return false;
            
            Money -= money;
            _textMoney.text = Money.ToString();
            
            return true;
        }

        public void UpdateMoney() => _textMoney.text = Money.ToString();
            
        public void SetMoneyForWin(int money)
        {
            if (money < 0) return;
            
            _moneyForWin = money;
            _textMoneyForWin.text = _moneyForWin.ToString();
        }

        public void Import(ProgressWallet progressWallet)
        {
            Money = progressWallet.MoneyCount;
            UpdateMoney();
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