using System.Linq;
using Level;
using UnityEngine;
using YG;

namespace Shop
{
    public class PurchasedLevelsLoader : MonoBehaviour
    {
        [SerializeField] private PurchasedLevelButton[] _levels;

        private void Start()
        {
            bool[] openedLevels = YandexGame.savesData.openLevels;
            
            for (int i = 0; i < _levels.Length - 1; i++) { if (openedLevels[i]) _levels[i].EndBuy(); }
        }

        public void UpdateOpenLevels()
        {
            YandexGame.savesData.openLevels = _levels.Select(x => x.IsPurchased).ToArray();
            YandexGame.SaveCloud();
        }
    }
}