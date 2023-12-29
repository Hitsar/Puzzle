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
            Load();
        }

        private void Load()
        {
            ProgressAsset progressAsset = LocalStorage.GetProgress();
            if (progressAsset == null)
                return;
            ImportWalletFrom(progressAsset);
            ImportLevelsFrom(progressAsset);
            Debug.Log("Game loaded");
        }

        private void ImportWalletFrom(ProgressAsset progressAsset) => _wallet.Import(progressAsset.ProgressWallet);

        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}