using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [System.Serializable]
    public class PuzzleData
    {
        [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    }
}