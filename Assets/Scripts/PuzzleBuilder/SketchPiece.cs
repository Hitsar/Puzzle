using Puzzles;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleBuilder
{
    public class SketchPiece : MonoBehaviour, IPuzzlePiece
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;
        
        public RectTransform RectTransform => _rectTransform;
        public Image Image => _image;
        public Sprite Sprite => _image.sprite;
    }
}

