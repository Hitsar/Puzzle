using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PuzzleBuilder
{
    public class PuzzleBuilderCore : MonoBehaviour
    {
        private MaxPuzzleArea _maxPuzzleArea;
        private PuzzleArea _puzzleArea;
        [SerializeField] private Vector2 _testResize;

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea, PuzzleArea puzzleArea)
        {
            _maxPuzzleArea = maxPuzzleArea;
            _puzzleArea = puzzleArea;
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

            Debug.Log(maxPuzzleAreaSize);
            _puzzleArea.Resize(_testResize, maxPuzzleAreaSize);
        }
    }
}

