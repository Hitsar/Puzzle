using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using UnityEngine.UI;
using PuzzleBuilder;
using System;

namespace Puzzles
{
    public class InteractivePuzzle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPuzzlePiece
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;
        [SerializeField] private SketchPiece _sketchPiece;
        private Canvas _canvas;
        private IPuzzleVFX _vfx;
        private GameStateObserver _gameStateObserver;
        private PuzzleDump _puzzleDump;
        private Vector2 _startPosition;

        public Image Image => _image;
        public Sprite Sprite => _image.sprite;
        public RectTransform RectTransform => _rectTransform;
        private const int closeDistanceModifier = 5;

        [Inject]
        public void Construct(Canvas canvas, IPuzzleVFX puzzleVfx, GameStateObserver gameStateObserver, PuzzleDump puzzleDump)
        {
            _canvas = canvas;
            _vfx = puzzleVfx;
            _vfx.SetTransform(_rectTransform);
            _gameStateObserver = gameStateObserver;
            _puzzleDump = puzzleDump;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            SetRayTarget(false);
            SetStartPosition(_rectTransform.position);
            _vfx.Select();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(_sketchPiece != null && Vector2.Distance(_rectTransform.position, _sketchPiece.RectTransform.position) < _rectTransform.sizeDelta.x / closeDistanceModifier)
            {
                _rectTransform.position = _sketchPiece.RectTransform.position;
                _rectTransform.SetParent(_sketchPiece.RectTransform);


                _gameStateObserver.AddPlacedPuzzles();
                _puzzleDump.ReplenishPuzzle();
            }
            else
            {
                MoveToStart();
                SetRayTarget(true);
            }
        }

        private void SetRayTarget(bool isActive) => _image.raycastTarget = isActive;
        public void SetStartPosition(Vector2 position) => _startPosition = position;
        public void ConnectToSketchPiece(SketchPiece sketchPiece) => _sketchPiece = sketchPiece;
        public void MoveToStart() => _vfx.MoveTo(_startPosition);
        
    }
}

