using PuzzleBuilder;
using SaveLoadSystem;
using Shop;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayStarter : MonoBehaviour
    {
        private PuzzleBuilderCore _puzzleBuilderCore;
        private MoneyLoader _moneyLoader;
        private Wallet _wallet;

        [Inject]
        public void Construct(PuzzleBuilderCore puzzleBuilderCore, MoneyLoader progressLoader, Wallet wallet)
        {
            _puzzleBuilderCore = puzzleBuilderCore;
            _moneyLoader = progressLoader;
            _wallet = wallet;
        }

        private void Start () 
        {
            _moneyLoader.LoadWallet();
            LoadReward();
            _puzzleBuilderCore.BuildPuzzle();
        }

        private void LoadReward()
        {
            int levelNumber = LevelNumberPasser.Instance != null ? LevelNumberPasser.LevelNumber : _puzzleBuilderCore.TestLevelNumber;
            _wallet.SetMoneyForWin(levelNumber);
        }
    }
}