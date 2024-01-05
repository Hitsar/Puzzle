using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PuzzleBuilder
{
    public class PiecesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _sketchPiecePrefab;
        private PuzzleResizer _puzzleResizer;
        [Inject]
        public void Construct(PuzzleResizer puzzleResizer)
        {
            _puzzleResizer = puzzleResizer;
        }

        public void CreatePieces(List<Sprite> sprites, Vector2 puzzleAreaSize, Vector2 originalImageSize)
        {
            foreach (var sprite in sprites) 
            {
                GameObject newPiece = Instantiate(_sketchPiecePrefab, gameObject.transform);
                SketchPiece sketchPieceComponent = newPiece.GetComponent<SketchPiece>();
                sketchPieceComponent.Image.sprite = sprite;
                _puzzleResizer.ResizePuzzlePiece(sketchPieceComponent, puzzleAreaSize, originalImageSize);
            }
        }
    }
}

