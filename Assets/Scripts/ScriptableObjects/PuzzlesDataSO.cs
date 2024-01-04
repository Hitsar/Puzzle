using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PuzzleData", order = 1)]
public class PuzzlesDataSO : ScriptableObject
{
    [SerializeField] private List<PuzzleData> puzzles;
}


