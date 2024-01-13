using SaveLoadSystem;
using Shop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level
{
    public class PurchasedLevelButton : LevelButton
    {
        [SerializeField] private int _price;
        [SerializeField] private GameObject _buyButton;
        
        [SerializeField] private bool _purchased;
        private Wallet _wallet;
        public bool IsPurchased => _purchased;
        public int Number => _level;
        
        [Inject]
        public void Construct(LevelSaver levelSaver, Wallet wallet)
        {
            _wallet = wallet;
        }

        protected virtual void AttendBuy()
        {
            if (!_wallet.RemoveMoney(_price)) return;
            Buy();
        }

        protected void Buy()
        {
            OpenAccessToLevel();
        }

        public override void LoadLevel()
        {
            if (!_purchased)
            {
                AttendBuy();
                return;
            }
            base.LoadLevel();
        }

        public void OpenAccessToLevel()
        {
            //Debug.Log("Level " + _levelNumber + " opened");
            GetComponent<Image>().color = Color.white;
            _purchased = true;
            _buyButton.SetActive(false);
        }
    }
}