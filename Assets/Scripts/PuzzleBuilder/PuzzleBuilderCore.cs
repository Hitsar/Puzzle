using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Zenject;

namespace PuzzleBuilder
{
    public class PuzzleBuilderCore : MonoBehaviour
    {
        [SerializeField] private int _testLevelNumber;

        private MaxPuzzleArea _maxPuzzleArea;
        private PuzzleArea _puzzleArea;
        private PuzzlesDataSO _puzzleDataSO;
        private PiecesSpawner _piecesSpawner;
        private GameStateObserver _gameStateObserver;
        private SketchPieceFactory _sketchPieceFactory;
        private InteractivePuzzleFactory _interactivePuzzleFactory;
        private SpriteSorter _spriteSorter;
        public int TestLevelNumber => _testLevelNumber;

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea, PuzzleArea puzzleArea, PuzzlesDataSO puzzlesDataSO, PiecesSpawner piecesSpawner, GameStateObserver gameStateObserver, SketchPieceFactory sketchPieceFactory, InteractivePuzzleFactory interactivePuzzleFactory, SpriteSorter spriteSorter)
        {
            _maxPuzzleArea = maxPuzzleArea;
            _puzzleArea = puzzleArea;
            _puzzleDataSO = puzzlesDataSO;
            _piecesSpawner = piecesSpawner;
            _gameStateObserver = gameStateObserver;
            _sketchPieceFactory = sketchPieceFactory;
            _interactivePuzzleFactory = interactivePuzzleFactory;
            _spriteSorter = spriteSorter;
        }

        public void BuildPuzzle()
        {
            Debug.Log("Build puzzle");
            StartCoroutine(WaitForEndOfFrame());
        }
        public IEnumerator WaitForEndOfFrame()
        {
            yield return new WaitForEndOfFrame();
            LateStart();
        }

        private void LateStart()
        {
            LoadFactories();
            PuzzleData puzzleData = GetPuzzleData();
            Vector2 puzzleAreaSize = _puzzleArea.Resize(puzzleData.PuzzleSize, _maxPuzzleArea.GetSize());
            List<Sprite> spriteList = GetSpriteList(puzzleData);
            _piecesSpawner.CreatePieces(spriteList, puzzleAreaSize, puzzleData.ImageSize, puzzleData.PuzzleSize);
            _gameStateObserver.Init(puzzleData.PuzzleSize);
        }

        private void LoadFactories()
        {
            _sketchPieceFactory.Load();
            _interactivePuzzleFactory.Load();
        }

        private PuzzleData GetPuzzleData()
        {
            int levelNumber = LevelNumberPasser.Instance != null ? LevelNumberPasser.LevelNumber : _testLevelNumber;
            return _puzzleDataSO.GetPuzzle(levelNumber);
        }

        private List<Sprite> GetSpriteList(PuzzleData puzzleData)
        {
            SpriteAtlas spriteAtlas = puzzleData.Atlas;
            Sprite[] sprites = new Sprite[(int)(puzzleData.PuzzleSize.x * puzzleData.PuzzleSize.y)];
            spriteAtlas.GetSprites(sprites);
            return  _spriteSorter.SortSprites(sprites);
        }
    }
}

