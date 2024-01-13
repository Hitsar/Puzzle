using System.Collections.Generic;
using System.Linq;
using Level;
using SaveLoadSystem;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class PurchasedLevelsLoader : MonoBehaviour, ISaveableLevels
    {
        [SerializeField] private List<PurchasedLevelButton> _allLevels;
        private List<int> _purchasedLevels = new List<int>();
        public void Import(ProgressLevels progressWallet)
        {
            _allLevels = LevelLinksHolder.Instance.Levels;
            _purchasedLevels = progressWallet._purchasedLevels;
            foreach(PurchasedLevelButton level in _allLevels) 
            {
                if(_purchasedLevels.Contains(level.Number))
                    level.OpenAccessToLevel();
            }
        }

        public ProgressLevels Export()
        {
            _purchasedLevels = GetPurchasedLevelsFromCurrentScene(_allLevels);
            return new ProgressLevels()
            {
                _purchasedLevels = this._purchasedLevels
            };
        }

        private List<int> GetPurchasedLevelsFromCurrentScene(List<PurchasedLevelButton> allLevels)
        {
            List<int> purchasedLevels = new List<int>();
            for (int i = 0; i < allLevels.Count; i++)
            {
                if (allLevels[i].IsPurchased)
                    purchasedLevels.Add(allLevels[i].Number);
            }

            return purchasedLevels;
        }
    }
}