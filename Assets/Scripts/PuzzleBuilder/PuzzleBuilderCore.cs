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
        private ConvexSizeCalculator _convexSizeCalculator;
        private PiecesSpawner _piecesSpawner;

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea, PuzzleArea puzzleArea, PuzzleSizeQualifier puzzleSizeQualifier, PuzzlesDataSO puzzlesDataSO, ConvexSizeCalculator convexSizeCalculator, PiecesSpawner piecesSpawner)
        {
            _maxPuzzleArea = maxPuzzleArea;
            _puzzleArea = puzzleArea;
            _puzzleSizeQualifier = puzzleSizeQualifier;
            _puzzleDataSO = puzzlesDataSO;
            _convexSizeCalculator = convexSizeCalculator;
            _piecesSpawner = piecesSpawner;
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
            Vector2 maxPuzzleAreaSize = _maxPuzzleArea.GetSize();
            PuzzleData puzzleData = _puzzleDataSO.GetPuzzle(_testLevelNumber);
            Vector2 puzzleAreaSize = _puzzleArea.Resize(puzzleData.Size, maxPuzzleAreaSize);

            Vector2 originalMinMax = _puzzleSizeQualifier.GetMinMaxSize(puzzleData.Sprites);
            float convex = _convexSizeCalculator.GetConvexSize(originalMinMax.x, originalMinMax.y);

            //Debug.Log("OriginalMinMax : " + originalMinMax);
            Debug.Log("Convex : " + convex);

            Vector2 originalImageSize = puzzleData.OriginalImage.rect.size;
            Debug.Log("OriginalImageSize : " + originalImageSize);
            Debug.Log("PuzzleAreaSize : " + puzzleAreaSize);

            _piecesSpawner.CreatePieces(puzzleData.Sprites, puzzleAreaSize, originalImageSize);
        }
    }
}

