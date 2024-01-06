using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Puzzles;
using Zenject;

namespace PuzzleBuilder
{
    public class PuzzleDump : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private LayoutPuzzleBar _puzzleBar;
        private List<InteractivePuzzle> _puzzlePieces = new List<InteractivePuzzle>();
        public RectTransform RectTransform => _rectTransform;

        public void ReplenishPuzzle()
        {
            if (_puzzlePieces.Count == 0)
                return;

            InteractivePuzzle puzzleToReplenish = _puzzlePieces[Random.Range(0, _puzzlePieces.Count)];
            RectTransform newSlot = FindObjectOfType<LayoutPuzzleBar>().GetNewSlotTransform();
            puzzleToReplenish.SetStartPosition(newSlot.position);
            puzzleToReplenish.MoveToStart();
            _puzzlePieces.Remove(puzzleToReplenish);
            puzzleToReplenish.transform.SetParent(newSlot);
        }

        public void SetPuzzlePieces(List<InteractivePuzzle> interactivePuzzles, int piecesInBar)
        {
            _puzzlePieces = interactivePuzzles;
            foreach (InteractivePuzzle piece in _puzzlePieces)
            {
                piece.transform.SetParent(_rectTransform);
                piece.transform.localScale = Vector3.one;
            }

            for (int i = 0; i < piecesInBar; i++) 
            {
                ReplenishPuzzle();
            }
        }


    }
}

