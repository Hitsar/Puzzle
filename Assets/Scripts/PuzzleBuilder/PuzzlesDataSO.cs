using System.Collections.Generic;
using UnityEngine;

namespace PuzzleBuilder
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PuzzleData", order = 1)]
    public class PuzzlesDataSO : ScriptableObject
    {
        [SerializeField] private List<PuzzleData> _puzzles;

        public PuzzleData GetPuzzle(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > _puzzles.Count)
            {
                Debug.LogError("Invalid level number");
                return null;
            }

            return _puzzles[levelNumber - 1];
        }
    }
}




