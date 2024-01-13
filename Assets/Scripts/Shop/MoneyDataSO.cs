using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MoneyData", order = 3)]
    public class MoneyDataSO : ScriptableObject
    {
        [SerializeField] private List<MoneyData> moneyDatas;

        public int GetReward(int levelNumber)
        {
            Debug.Log(levelNumber);
            if (levelNumber < 0 || levelNumber > moneyDatas.Count - 1)
            {
                Debug.LogError("Invalid LevelNumber");
                return 0;
            }

            return moneyDatas[levelNumber - 1].Reward;
        }
    }
}

