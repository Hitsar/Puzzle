using Audio;
using Puzzles;
using Shop;
using System;
using UI;
using UnityEngine;

namespace PuzzleBuilder
{
    public class GameStateObserver
    {
        private int _piecesInPuzzle = 0;
        private int _placedPieces = 0;
        private AudioSource _winAudio;
        public GameStateObserver(WinAudio winAudio) 
        {
            _winAudio = winAudio.AudioSource;
        }

        public void Init(Vector2 puzzleSize)
        {
            _piecesInPuzzle = (int)puzzleSize.x * (int)puzzleSize.y;
            InteractivePuzzle.PiecePlaced += AddPlacedPuzzles;
        }

        private void AddPlacedPuzzles(object sender, EventArgs e)
        {
            _placedPieces++;

            if (_placedPieces == _piecesInPuzzle)
            {
                FinishLevel();
            }
        }

        private void FinishLevel()
        {
            MonoBehaviour.FindAnyObjectByType<WinPanelAnimator>(FindObjectsInactive.Include).gameObject.SetActive(true);
            MonoBehaviour.FindAnyObjectByType<Wallet>().AddMoneyForWin();

            _winAudio.Play();
            InteractivePuzzle.PiecePlaced -= AddPlacedPuzzles;
        }
    }
}