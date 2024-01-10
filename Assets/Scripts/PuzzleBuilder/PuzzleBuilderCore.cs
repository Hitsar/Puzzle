using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PuzzleBuilder
{
    public class PuzzleBuilderCore : MonoBehaviour
    {
        [SerializeField] private int _testLevelNumber;

        private MaxPuzzleArea _maxPuzzleArea;
        private PuzzleArea _puzzleArea;
        private PuzzlesDataSO _puzzleDataSO;
        private PiecesSpawner _piecesSpawner;
        private GameStateObserver _gameStateObserver;
        private SketchPieceFactory _sketchPieceFactory;
        private InteractivePuzzleFactory _interactivePuzzleFactory;

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea, PuzzleArea puzzleArea, PuzzlesDataSO puzzlesDataSO, PiecesSpawner piecesSpawner, GameStateObserver gameStateObserver, SketchPieceFactory sketchPieceFactory, InteractivePuzzleFactory interactivePuzzleFactory)
        {
            _maxPuzzleArea = maxPuzzleArea;
            _puzzleArea = puzzleArea;
            _puzzleDataSO = puzzlesDataSO;
            _piecesSpawner = piecesSpawner;
            _gameStateObserver = gameStateObserver;
            _sketchPieceFactory = sketchPieceFactory;
            _interactivePuzzleFactory = interactivePuzzleFactory;
        }

        private void Start()
        {
            StartCoroutine(WaitForEndOfFrame());
        }
        public IEnumerator WaitForEndOfFrame()
        {
            yield return new WaitForEndOfFrame();
            LateStart();
        }

        private void LateStart()
        {
            _sketchPieceFactory.Load();
            _interactivePuzzleFactory.Load();
            int levelNumber = LevelNumberPasser.Instance != null ? LevelNumberPasser.LevelNumber : _testLevelNumber;

            PuzzleData puzzleData = _puzzleDataSO.GetPuzzle(levelNumber);
            Vector2 puzzleAreaSize = _puzzleArea.Resize(puzzleData.PuzzleSize, _maxPuzzleArea.GetSize());
            Vector2 originalImageSize = puzzleData.ImageSize;


            _piecesSpawner.CreatePieces(puzzleData.Sprites, puzzleAreaSize, originalImageSize, puzzleData.PuzzleSize);
            _gameStateObserver.Init(puzzleData.PuzzleSize);
        }
    }
}

