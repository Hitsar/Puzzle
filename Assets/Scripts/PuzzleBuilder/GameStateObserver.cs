using Audio;
using Puzzles;
using Shop;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace PuzzleBuilder
{
    public class GameStateObserver
    {
        private int _piecesInPuzzle = 0;
        private int _placedPieces = 0;
        private AudioSource _winAudio;
        private AudioSource _inPlaceAudio;
        [Inject]
        public GameStateObserver(WinAudio winAudio, AudioInPlace audioInPlace) 
        {
            _winAudio = winAudio.AudioSource;
            _inPlaceAudio = audioInPlace.AudioSource;
        }

        public void Init(Vector2 puzzleSize)
        {
            _piecesInPuzzle = (int)puzzleSize.x * (int)puzzleSize.y;
        }

        public void AddPlacedPuzzles()
        {
            _inPlaceAudio.Play();
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
        }
    }
}