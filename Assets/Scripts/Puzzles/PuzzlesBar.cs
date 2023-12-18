using Shop;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles
{
    public class PuzzlesBar : MonoBehaviour
    {
        [SerializeField] private PuzzleMovement[] _puzzles;
        [SerializeField] private Image _upperBar;
        
        [SerializeField] private AudioSource _audioInPlace;
        [SerializeField] private AudioSource _audioWin;
        
        private short _puzzle = -1;
        private short _puzzlesInPlaceCount = -4;
        
        public void ReplenishPuzzle(Vector2 position)
        {
            _audioInPlace.Play();
            _puzzlesInPlaceCount++;
            _puzzle++;
            
            if (_puzzlesInPlaceCount == _puzzles.Length)
            {
                FindAnyObjectByType<WinMenu>(FindObjectsInactive.Include).gameObject.SetActive(true);
                FindAnyObjectByType<Wallet>().AddMoneyForWin();
                _audioWin.Play();
                return;
            }
            
            if (_puzzle >= _puzzles.Length) return;
            
            PuzzleMovement puzzle = _puzzles[_puzzle];
            puzzle.SetStartPosition(position);
            puzzle.MoveToStart();
            puzzle.SetRayTarget(true);
        }

        public void CloseOrOpen(bool isClose) => _upperBar.raycastTarget = isClose;
    }
}