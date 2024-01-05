using Puzzles;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PuzzleBuilder
{
    public class PiecesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _sketchPiecePrefab;
        [SerializeField] private GameObject _interactivePiecePrefab;
        private PuzzleResizer _puzzleResizer;
        private PuzzlePlacer _puzzlePlacer;
        private PuzzleSizeQualifier _puzzleSizeQualifier;
        private ConvexSizeCalculator _convexSizeCalculator;
        private LayoutPuzzleBar _layoutPuzzleBar;
        private Canvas _canvas;
        private PuzzleDump _puzzleDump; 
        [Inject]
        public void Construct(PuzzleResizer puzzleResizer, PuzzlePlacer puzzlePlacer, PuzzleSizeQualifier puzzleSizeQualifier, ConvexSizeCalculator convexSizeCalculator, LayoutPuzzleBar layoutPuzzleBar, Canvas canvas, PuzzleDump puzzleDump)
        {
            _puzzleResizer = puzzleResizer;
            _puzzlePlacer = puzzlePlacer;
            _puzzleSizeQualifier = puzzleSizeQualifier;
            _convexSizeCalculator = convexSizeCalculator;
            _layoutPuzzleBar = layoutPuzzleBar;
            _canvas = canvas;
            _puzzleDump = puzzleDump;
        }

        public void CreatePieces(List<Sprite> sprites, Vector2 puzzleAreaSize, Vector2 originalImageSize, Vector2 dimensionalSize)
        {
            List<SketchPiece> spawnedPieces = new List<SketchPiece>();
            List<InteractivePuzzle> interactivePuzzles = new List<InteractivePuzzle>();
            foreach (var sprite in sprites) 
            {
                GameObject newPiece = Instantiate(_sketchPiecePrefab, gameObject.transform);
                SketchPiece sketchPieceComponent = newPiece.GetComponent<SketchPiece>();
                sketchPieceComponent.Image.sprite = sprite;
                _puzzleResizer.ResizePuzzlePiece(sketchPieceComponent, puzzleAreaSize, originalImageSize);
                spawnedPieces.Add(sketchPieceComponent);

                GameObject newInteractivePiece = Instantiate(_interactivePiecePrefab);
                InteractivePuzzle interactivePuzzleComponent = newInteractivePiece.GetComponent<InteractivePuzzle>();
                interactivePuzzleComponent.ConnectToSketchPiece(sketchPieceComponent);
                interactivePuzzleComponent.Image.sprite = sprite;
                interactivePuzzleComponent.SetCanvas(_canvas);
                _puzzleResizer.ResizePuzzlePiece(interactivePuzzleComponent, puzzleAreaSize, originalImageSize);
                interactivePuzzles.Add(interactivePuzzleComponent);
            }

            Vector2 adaptedMinMax = _puzzleSizeQualifier.GetMinMaxSize(spawnedPieces);
            float convexSize = _convexSizeCalculator.GetConvexSize(adaptedMinMax.x, adaptedMinMax.y);
            Debug.Log("AdaptedMinMax: " + adaptedMinMax);
            Debug.Log("Convex: " + convexSize);

            foreach (var piece in  spawnedPieces)
            {
                _puzzlePlacer.PlacePieceOnPosition(piece.RectTransform, adaptedMinMax, convexSize, puzzleAreaSize, dimensionalSize);
            }

            _layoutPuzzleBar.PrepareSlots((int)dimensionalSize.x, new Vector2(adaptedMinMax.y, adaptedMinMax.y) / 1.7f);

            _puzzleDump.SetPuzzlePieces(interactivePuzzles, (int)dimensionalSize.x);
        }
    }
}

