using Config;
using Shop;
using TMPro;
using UI;
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

        [Header("Should be negative of pieces in bar")]
        [SerializeField] private short _puzzlesInPlaceCount;

        private short _puzzle = -1;
        public void ReplenishPuzzle(Vector2 position)
        {
            _audioInPlace.Play();

            _puzzlesInPlaceCount++;
            _puzzle++;
            
            if (_puzzlesInPlaceCount == _puzzles.Length)
            {
                FinishLevel();
                return;
            }
            
            if (_puzzle >= _puzzles.Length) return;
            
            PuzzleMovement puzzle = _puzzles[_puzzle];
            puzzle.SetStartPosition(position);
            puzzle.MoveToStart();
            puzzle.SetRayTarget(true);
        }

        public void SetClose(bool isClose) => _upperBar.raycastTarget = isClose;

        private void FinishLevel()
        {
            FindAnyObjectByType<WinPanelAnimator>(FindObjectsInactive.Include).gameObject.SetActive(true);
            FindAnyObjectByType<Wallet>().AddMoneyForWin();

            _audioWin.Play();
        }
    }
}