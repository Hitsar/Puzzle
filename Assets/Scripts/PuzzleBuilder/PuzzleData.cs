using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace PuzzleBuilder
{
    [System.Serializable]
    public class PuzzleData
    {
        [Header("Width x Height")]
        [SerializeField] private Vector2 _size;
        [SerializeField] private Sprite _originalImage;
        [SerializeField] private SpriteAtlas _atlas;
        public Vector2 PuzzleSize => _size;
        public Sprite OriginalImage => _originalImage;
        public Vector2 ImageSize => OriginalImage.rect.size;
        public SpriteAtlas Atlas => _atlas;
    }
}