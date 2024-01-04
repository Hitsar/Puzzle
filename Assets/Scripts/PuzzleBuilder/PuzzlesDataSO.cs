using System.Collections.Generic;
using UnityEngine;

namespace PuzzleBuilder
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PuzzleData", order = 1)]
    public class PuzzlesDataSO : ScriptableObject
    {
        [SerializeField] private List<PuzzleData> puzzles;
    }
}




