using UnityEngine;

namespace Level
{
    public class AdvertisingLevelButton : PurchasedLevelButton
    {
        protected override void Buy()
        {
            //TODO: показ рекламы, а пока будет так.
            Debug.Log("========Реклама========");
            EndBuy();
        }
    }
}