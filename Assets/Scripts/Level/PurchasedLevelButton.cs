using Shop;
using UnityEngine;

namespace Level
{
    public class PurchasedLevelButton : LevelButton
    {
        [SerializeField] private int _price;
        [SerializeField] private GameObject _buyButton;
        private bool _isPurchased;
        
        private void Buy()
        {
            if (!FindAnyObjectByType<Wallet>().RemoveMoney(_price)) return;
            
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