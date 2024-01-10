using Puzzles;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PuzzleBuilder
{
    public class PiecesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _interactivePiecePrefab;
        private PuzzleResizer _puzzleResizer;
        private PuzzlePlacer _puzzlePlacer;
        private PuzzleSizeQualifier _puzzleSizeQualifier;
        private LayoutPuzzleBar _layoutPuzzleBar;
        private PuzzleDump _puzzleDump;
        private SketchPieceFactory _sketchPieceFactory;
        private InteractivePuzzleFactory _interactivePuzzleFactory;
        [Inject]
        public void Construct(PuzzleResizer puzzleResizer, PuzzlePlacer puzzlePlacer, PuzzleSizeQualifier puzzleSizeQualifier, LayoutPuzzleBar layoutPuzzleBar, PuzzleDump puzzleDump, SketchPieceFactory sketchPieceFactory, InteractivePuzzleFactory interactivePuzzleFactory)
        {
            _puzzleResizer = puzzleResizer;
            _puzzlePlacer = puzzlePlacer;
            _puzzleSizeQualifier = puzzleSizeQualifier;
            _layoutPuzzleBar = layoutPuzzleBar;
            _puzzleDump = puzzleDump;
            _sketchPieceFactory = sketchPieceFactory;
            _interactivePuzzleFactory = interactivePuzzleFactory;
        }

        public void CreatePieces(List<Sprite> sprites, Vector2 puzzleAreaSize, Vector2 originalImageSize, Vector2 dimensionalSize)
        {
            List<SketchPiece> spawnedPieces = new List<SketchPiece>();
            List<InteractivePuzzle> interactivePuzzles = new List<InteractivePuzzle>();
            foreach (var sprite in sprites) 
            {
                SketchPiece newSketchPiece = _sketchPieceFactory.Create(sprite);
                _puzzleResizer.ResizePuzzlePiece(newSketchPiece, puzzleAreaSize, originalImageSize);
                spawnedPieces.Add(newSketchPiece);

                InteractivePuzzle newInteractivePuzzle = _interactivePuzzleFactory.Create(sprite, newSketchPiece);
                _puzzleResizer.ResizePuzzlePiece(newInteractivePuzzle, puzzleAreaSize, originalImageSize);
                interactivePuzzles.Add(newInteractivePuzzle);
            }

            Vector2 adaptedMinMax = _puzzleSizeQualifier.GetMinMaxSize(spawnedPieces);
            Vector2 adaptedMaxSize = new Vector2(adaptedMinMax.y, adaptedMinMax.y);
            foreach (var piece in  spawnedPieces)
            {
                _puzzlePlacer.PlacePieceOnPosition(piece.RectTransform, adaptedMinMax, GetConvexSize(adaptedMinMax.x, adaptedMinMax.y), puzzleAreaSize, dimensionalSize);
            }

            _layoutPuzzleBar.PrepareSlots((int)dimensionalSize.x, adaptedMaxSize / 1.7f);
            _puzzleDump.SetPuzzlePieces(interactivePuzzles, (int)dimensionalSize.x);
        }

        public float GetConvexSize(float minSize, float maxSize)
        {
            return (maxSize - minSize) / 2;
        }
    }
}

