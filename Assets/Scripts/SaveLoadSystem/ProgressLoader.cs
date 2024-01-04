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
            var progressAsset = LocalStorage.GetProgress();
            ImportWalletFrom(progressAsset);
            Debug.Log("Game loaded");
        }

        public void Load()
        {
            var progressAsset = LocalStorage.GetProgress();
            ImportLevelsFrom(progressAsset);
        }

        private void ImportWalletFrom(ProgressAsset progressAsset) => _wallet.Import(progressAsset.ProgressWallet);
        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}