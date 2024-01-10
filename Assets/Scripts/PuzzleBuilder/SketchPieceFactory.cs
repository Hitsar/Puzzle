using UnityEngine;
using Zenject;

namespace PuzzleBuilder
{
    public class SketchPieceFactory
    {
        private readonly DiContainer _diContainer;
        private const string _sketchPieceName = "SketchPiece";
        private Object _sketchPiecePrefab;
        private PuzzleArea _puzzleArea;

        [Inject]
        public SketchPieceFactory(DiContainer diContainer, PuzzleArea puzzleArea)
        {
            _diContainer = diContainer;
            _puzzleArea = puzzleArea;
        }

        public void Load()
        {
            _sketchPiecePrefab = Resources.Load(_sketchPieceName);
        }

        public SketchPiece Create(Sprite newSprite)
        {
            SketchPiece newSketchPiece = _diContainer.InstantiatePrefab(_sketchPiecePrefab, _puzzleArea.transform).GetComponent<SketchPiece>();
            newSketchPiece.Image.sprite = newSprite;
            return newSketchPiece;
        }
    }
}