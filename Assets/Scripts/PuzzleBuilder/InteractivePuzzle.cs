using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using UnityEngine.UI;
using PuzzleBuilder;

namespace Puzzles
{
    public class InteractivePuzzle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;
        [SerializeField] private SketchPiece _sketchPiece;
        private Canvas _canvas;
        private PuzzleVfx _vfx;
        private Vector2 _startPosition;

        private const int closeDistanceModifier = 16;
        [Inject]
        public void Construct(Canvas canvas, PuzzleVfx puzzleVfx)
        {
            _canvas = canvas;
            SetStartPosition(_rectTransform.position);
            _vfx = puzzleVfx;
            _vfx.SetTransform(_rectTransform);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            SetRayTarget(false);
            _sketchPiece.SetRayTarget(true);
            SetStartPosition(_rectTransform.position);
            _vfx.Select();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _sketchPiece.SetRayTarget(false);

            if( Vector2.Distance(_rectTransform.position, _sketchPiece.RectTransform.position) < _rectTransform.sizeDelta.x / closeDistanceModifier)
            {
                _rectTransform.position = _sketchPiece.RectTransform.position;
            }
            else
            {
                MoveToStart();
                SetRayTarget(true);
            }
        }

        public void SetRayTarget(bool isActive) => _image.raycastTarget = isActive;
        public void SetStartPosition(Vector2 position) => _startPosition = position;
        public void MoveToStart() => _vfx.MoveTo(_startPosition);
    }
}

