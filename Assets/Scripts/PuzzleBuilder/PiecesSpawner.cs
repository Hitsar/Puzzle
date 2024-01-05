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
        private PuzzlePlacer _puzzlePlacer;
        private PuzzleSizeQualifier _puzzleSizeQualifier;
        private ConvexSizeCalculator _convexSizeCalculator;
        [Inject]
        public void Construct(PuzzleResizer puzzleResizer, PuzzlePlacer puzzlePlacer, PuzzleSizeQualifier puzzleSizeQualifier, ConvexSizeCalculator convexSizeCalculator)
        {
            _puzzleResizer = puzzleResizer;
            _puzzlePlacer = puzzlePlacer;
            _puzzleSizeQualifier = puzzleSizeQualifier;
            _convexSizeCalculator = convexSizeCalculator;
        }

        public void CreatePieces(List<Sprite> sprites, Vector2 puzzleAreaSize, Vector2 originalImageSize, Vector2 dimensionalSize)
        {
            List<SketchPiece> spawnedPieces = new List<SketchPiece>(); 
            foreach (var sprite in sprites) 
            {
                GameObject newPiece = Instantiate(_sketchPiecePrefab, gameObject.transform);
                SketchPiece sketchPieceComponent = newPiece.GetComponent<SketchPiece>();
                sketchPieceComponent.Image.sprite = sprite;
                _puzzleResizer.ResizePuzzlePiece(sketchPieceComponent, puzzleAreaSize, originalImageSize);
                spawnedPieces.Add(sketchPieceComponent);
            }

            Vector2 adaptedMinMax = _puzzleSizeQualifier.GetMinMaxSize(spawnedPieces);
            float convexSize = _convexSizeCalculator.GetConvexSize(adaptedMinMax.x, adaptedMinMax.y);
            Debug.Log("AdaptedMinMax: " + adaptedMinMax);
            Debug.Log("Convex: " + convexSize);

            foreach (var piece in  spawnedPieces)
            {
                _puzzlePlacer.PlacePieceOnPosition(piece.RectTransform, adaptedMinMax, convexSize, puzzleAreaSize, dimensionalSize);
            }
        }
    }
}

