using Shop;
using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public class PurchasedLevelButton : LevelButton
    {
        [SerializeField] private int _price;
        [SerializeField] private GameObject _buyButton;
        private bool _isPurchased;
        
        protected virtual void Buy()
        {
            if (!FindAnyObjectByType<Wallet>().RemoveMoney(_price)) return;
            EndBuy();
        }

        protected void EndBuy()
        {
            GetComponent<Image>().color = Color.white;
            _isPurchased = true;
            _buyButton.SetActive(false);
        }

        public override void LoadLevel()
        {
            if (!_isPurchased)
            {
                Buy();
                return;
            }
            base.LoadLevel();
        }
    }
}