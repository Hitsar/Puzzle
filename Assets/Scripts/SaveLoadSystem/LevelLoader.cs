using Shop;
using System.Collections;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class LevelLoader
    {
        private PurchasedLevelsLoader _purchasedLevelsLoader;

        [Inject]
        public void Construct(PurchasedLevelsLoader purchasedLevelsLoader)
        {
            _purchasedLevelsLoader = purchasedLevelsLoader;
        }

        public void Load()
        {
            var progressAsset = LocalStorage.GetProgress();
            ImportLevelsFrom(progressAsset);
        }

        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}