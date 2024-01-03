using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzles
{
    public class PuzzleMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private RectTransform _transform;
        private Image _image;
        private PuzzleVfx _vfx;
        
        private PuzzleSlot _parent;
        private Canvas _canvas;
        
        private PuzzlesBar _puzzlesBar;
        private Vector2 _startPosition;

        private void Start()
        {
            _transform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            _vfx = new PuzzleVfx(transform);
            
            _canvas = GetComponentInParent<Canvas>();
            _parent = GetComponentInParent<PuzzleSlot>();
            _puzzlesBar = FindAnyObjectByType<PuzzlesBar>();
            
            SetStartPosition(_transform.position);
        }
        
        public void SetStartPosition(Vector2 position) => _startPosition = position;
        public void SetRayTarget(bool isActive) => _image.raycastTarget = isActive;
        
        public void MoveToStart() => _vfx.MoveTo(_startPosition);

        public void OnDrag(PointerEventData eventData) => _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _puzzlesBar.SetClose(true);
            SetRayTarget(false);
            _parent.ChangeRayTarget(true);
            _parent.transform.SetAsLastSibling();
            _vfx.Select();
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            _puzzlesBar.SetClose(false);
            _parent.ChangeRayTarget(false);

            if (_transform.localPosition == Vector3.zero) _puzzlesBar.ReplenishPuzzle(_startPosition);
            else
            {
                MoveToStart();
                SetRayTarget(true);
            }
        }
    }
}