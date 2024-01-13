using Shop;
using System.Collections;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class LevelLoader
    {
        private PurchasedLevelsLoader _purchasedLevelsLoader;
        private LocalStorage _localStorage;

        [Inject]
        public void Construct(PurchasedLevelsLoader purchasedLevelsLoader, LocalStorage localStorage)
        {
            _purchasedLevelsLoader = purchasedLevelsLoader;
            _localStorage = localStorage;
        }

        public void Load()
        {
            var progressAsset = _localStorage.GetProgress();
            ImportLevelsFrom(progressAsset);
        }

        private void ImportLevelsFrom(ProgressAsset progressAsset) => _purchasedLevelsLoader.Import(progressAsset.ProgressLevels);
    }
}