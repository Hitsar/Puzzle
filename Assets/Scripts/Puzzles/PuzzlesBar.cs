using Shop;
using Ui;
using UnityEngine;

namespace Puzzles
{
    public class PuzzlesBar : MonoBehaviour
    {
        [SerializeField] private PuzzleMovement[] _puzzles;
        private short _puzzle = -1;
        private short _puzzlesInPlaceCount = -1;

        public void ReplenishPuzzle(Vector2 position)
        {
            _puzzlesInPlaceCount++;
            _puzzle++;
            if (_puzzlesInPlaceCount == _puzzles.Length)
            {
                FindAnyObjectByType<WinMenu>(FindObjectsInactive.Include).gameObject.SetActive(true);
                FindAnyObjectByType<Wallet>().AddMoneyForWin();
                return;
            }
            
            PuzzleMovement puzzle = _puzzles[_puzzle];
            puzzle.SetStartPosition(position);
            puzzle.MoveToStart();
            puzzle.SetRayTarget(true);
        }
    }
}