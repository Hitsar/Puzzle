using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzleBuilder
{
    [System.Serializable]
    public class PuzzleData
    {
        [Header("Width x Height")]
        [SerializeField] private Vector2 _size;
        [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    }
}