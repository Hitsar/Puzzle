using Shop;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Level
{
    public class PurchasedLevelButton : LevelButton
    {
        [SerializeField] private int _price;
        [SerializeField] private GameObject _buyButton;
        public bool IsPurchased { get; private set; }
        
        protected virtual void Buy()
        {
            if (!FindAnyObjectByType<Wallet>().RemoveMoney(_price)) return;
            EndBuy();
        }

        public void EndBuy()
        {
            GetComponent<Image>().color = Color.white;
            IsPurchased = true;
            _buyButton.SetActive(false);
        }

        public override void LoadLevel()
        {
            if (!IsPurchased)
            {
                Buy();
                return;
            }
            base.LoadLevel();
        }
    }
}