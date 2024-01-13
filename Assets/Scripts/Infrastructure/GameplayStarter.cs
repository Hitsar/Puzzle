using Localization;
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
        private Language _language;

        [Inject]
        public void Construct(PuzzleBuilderCore puzzleBuilderCore, MoneyLoader progressLoader, Wallet wallet, Language language)
        {
            _puzzleBuilderCore = puzzleBuilderCore;
            _moneyLoader = progressLoader;
            _wallet = wallet;
            _language = language;
        }

        private void Awake() 
        {
            _language.Init();
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