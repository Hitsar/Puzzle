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
        private LevelRewardDisplay _levelRewardDisplay;
        private Wallet _wallet;
        [Inject]
        public GameStateObserver(WinAudio winAudio, AudioInPlace audioInPlace, LevelRewardDisplay levelRewardDisplay, Wallet wallet) 
        {
            _winAudio = winAudio.AudioSource;
            _inPlaceAudio = audioInPlace.AudioSource;
            _levelRewardDisplay = levelRewardDisplay;
            _wallet = wallet;
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
            _levelRewardDisplay.UpdateLevelRewardText(_wallet.LevelReward);
            _wallet.AddMoneyForWin();
            MonoBehaviour.FindAnyObjectByType<WinPanelAnimator>(FindObjectsInactive.Include).gameObject.SetActive(true);
            

            _winAudio.Play();
        }
    }
}