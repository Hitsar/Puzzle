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
        private PuzzleSizeQualifier _puzzleSizeQualifier;
        private PuzzlesDataSO _puzzleDataSO;
        private PiecesSpawner _piecesSpawner;
        private GameStateObserver _gameStateObserver;

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea, PuzzleArea puzzleArea, PuzzleSizeQualifier puzzleSizeQualifier, PuzzlesDataSO puzzlesDataSO, PiecesSpawner piecesSpawner, GameStateObserver gameStateObserver)
        {
            _maxPuzzleArea = maxPuzzleArea;
            _puzzleArea = puzzleArea;
            _puzzleSizeQualifier = puzzleSizeQualifier;
            _puzzleDataSO = puzzlesDataSO;
            _piecesSpawner = piecesSpawner;
            _gameStateObserver = gameStateObserver;
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
            int levelNumber;
            if (LevelNumberPasser.Instance != null)
            {
                levelNumber = LevelNumberPasser.LevelNumber;
            }
            else
            {
                levelNumber = _testLevelNumber;
            }

            Vector2 maxPuzzleAreaSize = _maxPuzzleArea.GetSize();
            PuzzleData puzzleData = _puzzleDataSO.GetPuzzle(levelNumber);
            Vector2 puzzleAreaSize = _puzzleArea.Resize(puzzleData.Size, maxPuzzleAreaSize);

            Vector2 originalMinMax = _puzzleSizeQualifier.GetMinMaxSize(puzzleData.Sprites);
            //Debug.Log("OriginalMinMax : " + originalMinMax);

            Vector2 originalImageSize = puzzleData.OriginalImage.rect.size;

            _piecesSpawner.CreatePieces(puzzleData.Sprites, puzzleAreaSize, originalImageSize, puzzleData.Size);
            _gameStateObserver.Init(puzzleData.Size);
        }
    }
}

