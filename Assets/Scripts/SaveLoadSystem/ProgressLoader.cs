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

        private void Load() => LocalStorage.LoadProgress();

        private void ImportWalletFrom(ProgressAsset progressAsset) => _wallet.Import(progressAsset.ProgressWallet);

        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}