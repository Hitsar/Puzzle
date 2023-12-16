using DG.Tweening;
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

        private void OnValidate()
        {
            if (_transform == null) _transform = GetComponent<RectTransform>();
            if (_image == null) _image = GetComponent<Image>();
            if (_vfx == null) _vfx = GetComponent<PuzzleVfx>();
            
            if (_canvas == null) _canvas = GetComponentInParent<Canvas>();
            if (_parent == null) _parent = GetComponentInParent<PuzzleSlot>();
            if (_puzzlesBar == null) _puzzlesBar = FindAnyObjectByType<PuzzlesBar>();
        }

        private void Start() => SetStartPosition(_transform.position);

        public void SetStartPosition(Vector2 position) => _startPosition = position;
        public void SetRayTarget(bool isActive) => _image.raycastTarget = isActive;
        
        public void MoveToStart() => _vfx.MoveTo(_startPosition);

        public void OnDrag(PointerEventData eventData) => _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        public void OnBeginDrag(PointerEventData eventData)
        {
            SetRayTarget(false);
            _parent.ChangeRayTarget(true);
            _parent.transform.SetAsLastSibling();
            _vfx.Select();
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            _parent.ChangeRayTarget(false);

            if (_transform.localPosition == Vector3.zero) _puzzlesBar.ReplenishPuzzle(_startPosition);
            else
            {
                MoveToStart();
                SetRayTarget(true);
            }
            _vfx.Deselect();
        }
    }
}