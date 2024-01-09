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
        private LayoutPuzzleBar _layoutPuzzleBar;
        private Canvas _canvas;
        private PuzzleDump _puzzleDump; 
        private GameStateObserver _gameStateObserver;
        [Inject]
        public void Construct(PuzzleResizer puzzleResizer, PuzzlePlacer puzzlePlacer, PuzzleSizeQualifier puzzleSizeQualifier, LayoutPuzzleBar layoutPuzzleBar, Canvas canvas, PuzzleDump puzzleDump, GameStateObserver gameStateObserver)
        {
            _puzzleResizer = puzzleResizer;
            _puzzlePlacer = puzzlePlacer;
            _puzzleSizeQualifier = puzzleSizeQualifier;
            _layoutPuzzleBar = layoutPuzzleBar;
            _canvas = canvas;
            _puzzleDump = puzzleDump;
            _gameStateObserver = gameStateObserver;
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

                GameObject newInteractivePiece = Instantiate(_interactivePiecePrefab, _puzzleDump.transform);
                InteractivePuzzle interactivePuzzleComponent = newInteractivePiece.GetComponent<InteractivePuzzle>();
                interactivePuzzleComponent.ConnectToSketchPiece(sketchPieceComponent);
                interactivePuzzleComponent.Image.sprite = sprite;
                interactivePuzzleComponent.SetCanvas(_canvas);
                interactivePuzzleComponent.SetPuzzleDump(_puzzleDump);
                interactivePuzzleComponent.SetGameStateObserver(_gameStateObserver);
                _puzzleResizer.ResizePuzzlePiece(interactivePuzzleComponent, puzzleAreaSize, originalImageSize);
                interactivePuzzles.Add(interactivePuzzleComponent);
            }

            Vector2 adaptedMinMax = _puzzleSizeQualifier.GetMinMaxSize(spawnedPieces);
            float convexSize = GetConvexSize(adaptedMinMax.x, adaptedMinMax.y);

            foreach (var piece in  spawnedPieces)
            {
                _puzzlePlacer.PlacePieceOnPosition(piece.RectTransform, adaptedMinMax, convexSize, puzzleAreaSize, dimensionalSize);
            }

            _layoutPuzzleBar.PrepareSlots((int)dimensionalSize.x, new Vector2(adaptedMinMax.y, adaptedMinMax.y) / 1.7f);

            _puzzleDump.SetPuzzlePieces(interactivePuzzles, (int)dimensionalSize.x);
        }

        public float GetConvexSize(float minSize, float maxSize)
        {
            return (maxSize - minSize) / 2;
        }
    }
}

