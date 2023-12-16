using Shop;
using UnityEngine;

namespace Level
{
    public class PurchasedLevelButton : LevelButton
    {
        [SerializeField] private int _price;
        private bool _isPurchased;
        
        public void Buy() => _isPurchased = FindAnyObjectByType<Wallet>().RemoveMoney(_price);

        public override void LoadLevel() { if (_isPurchased) base.LoadLevel(); }
    }
}