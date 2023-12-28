using System;
using System.Linq;
using Level;
using Saves;
using UnityEngine;

namespace Shop
{
    public class PurchasedLevelsLoader : MonoBehaviour, ISaveableLevels
    {
        [field: SerializeField] public PurchasedLevelButton[] Levels { get; private set; }

        private void Awake()
        {
            print(gameObject.name);
        }

        public void Import(ProgressLevels progressWallet)
        {
            Levels = progressWallet.Levels.ToArray();
        }

        public ProgressLevels Export()
        {
            return new ProgressLevels
            {
                Levels = Levels.ToList()
            };
        }
    }
}