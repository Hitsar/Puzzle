using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Puzzles;
using Zenject;
using System;

namespace PuzzleBuilder
{
    public class PuzzleDump : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        private LayoutPuzzleBar _puzzleBar;
        private List<InteractivePuzzle> _puzzlePieces = new List<InteractivePuzzle>();
        public RectTransform RectTransform => _rectTransform;

        [Inject]
        public void Construct(LayoutPuzzleBar layoutPuzzleBar)
        {
            _puzzleBar = layoutPuzzleBar;
            InteractivePuzzle.PiecePlaced += ReplenishPuzzle;
        }

        private void ReplenishPuzzle(object sender, EventArgs e)
        {
            ReplenishPuzzle();
        }

        private void ReplenishPuzzle()
        {
            InteractivePuzzle puzzleToReplenish = _puzzlePieces[0];
            RectTransform newSlot = _puzzleBar.GetNewSlotTransform();
            puzzleToReplenish.SetStartPosition(newSlot.position);
            puzzleToReplenish.MoveToStart();
            _puzzlePieces.Remove(puzzleToReplenish);
            puzzleToReplenish.transform.SetParent(newSlot);

            if (_puzzlePieces.Count == 0)
                InteractivePuzzle.PiecePlaced -= ReplenishPuzzle;
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

