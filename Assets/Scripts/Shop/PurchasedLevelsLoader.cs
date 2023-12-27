using System.Linq;
using Level;
using Saves;
using UnityEngine;

namespace Shop
{
    public class PurchasedLevelsLoader : MonoBehaviour, ISaveableLevels
    {
        [SerializeField] private PurchasedLevelButton[] _levels;

        public void Import(ProgressLevels progressWallet)
        {
            _levels = progressWallet.Levels.ToArray();
        }

        public ProgressLevels Export()
        {
            return new ProgressLevels
            {
                Levels = _levels.ToList()
            };
        }
    }
}