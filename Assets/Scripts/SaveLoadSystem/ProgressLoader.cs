using Shop;
using TMPro;
using UnityEngine;

namespace Saves
{
    public class ProgressLoader : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private PurchasedLevelsLoader _purchasedLevelsLoader;
        [SerializeField] private TextMeshProUGUI _textMeshProUgui;
        
        private void Awake()
        {
            Debug.Log("Trying to load a game");
            Load();
        }

        private void Load()
        {
            var progressAsset = LocalStorage.GetProgress();
            ImportWalletFrom(progressAsset);
            ImportLevelsFrom(progressAsset);
            Debug.Log("Game loaded");
        }

        private void ImportWalletFrom(ProgressAsset progressAsset) => _wallet.Import(progressAsset.ProgressWallet);

        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}