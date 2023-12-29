using Shop;
using UnityEngine;

namespace Saves
{
    public class ProgressLoader : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private PurchasedLevelsLoader _purchasedLevelsLoader;
        
        private void Awake()
        {
            Debug.Log("Trying to load a game");
            LocalStorage.Load();
        }

        public void Load(string value)
        {
            var progressAsset = JsonUtility.FromJson<ProgressAsset>(value);
            ImportWalletFrom(progressAsset);
            ImportLevelsFrom(progressAsset);
            Debug.Log("Game loaded");
        }

        private void ImportWalletFrom(ProgressAsset progressAsset) => _wallet.Import(progressAsset.ProgressWallet);

        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}