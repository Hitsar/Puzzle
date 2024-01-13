using System.Collections;
using UnityEngine;

namespace Shop
{
    [System.Serializable]
    public class MoneyData
    {
        [SerializeField] private int _levelNumber;
        [SerializeField] private int _reward;
        public int Reward => _reward;
    }
}