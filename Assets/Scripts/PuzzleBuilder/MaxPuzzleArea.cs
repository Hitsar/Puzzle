using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleBuilder
{
    public class MaxPuzzleArea : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        public RectTransform RectTransform => _rectTransform;

        public Vector2 GetSize()
        {
            return _rectTransform.rect.size;
        }
    }
}

