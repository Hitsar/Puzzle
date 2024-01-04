using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PuzzleBuilder
{
    public class PuzzleBuilderCore : MonoBehaviour
    {
        private MaxPuzzleArea _maxPuzzleArea;

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea)
        {
            _maxPuzzleArea = maxPuzzleArea;
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
            Debug.Log(_maxPuzzleArea.GetSize());
        }
    }
}

