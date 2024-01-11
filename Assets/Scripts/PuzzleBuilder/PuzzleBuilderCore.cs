using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;
using Zenject;
using System.Linq;

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

        [Inject]
        public void Construct(MaxPuzzleArea maxPuzzleArea, PuzzleArea puzzleArea, PuzzlesDataSO puzzlesDataSO, PiecesSpawner piecesSpawner, GameStateObserver gameStateObserver, SketchPieceFactory sketchPieceFactory, InteractivePuzzleFactory interactivePuzzleFactory)
        {
            _maxPuzzleArea = maxPuzzleArea;
            _puzzleArea = puzzleArea;
            _puzzleDataSO = puzzlesDataSO;
            _piecesSpawner = piecesSpawner;
            _gameStateObserver = gameStateObserver;
            _sketchPieceFactory = sketchPieceFactory;
            _interactivePuzzleFactory = interactivePuzzleFactory;
        }

        private void Start()
        {
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
            return SortSprites(sprites);
        }

        private List<Sprite> SortSprites(Sprite[] sprites)
        {
            Dictionary<string, Sprite> keyValuePairs = new Dictionary<string, Sprite>();

            for (int i = 0; i < sprites.Length; i++)
            {
                string number = "";
                foreach (char c in sprites[i].name)
                {
                    if (char.IsNumber(c))
                        number += c;
                }
                
                keyValuePairs.Add(number, sprites[i]);
            }

            keyValuePairs = keyValuePairs.OrderBy(obj => int.Parse(obj.Key)).ToDictionary(obj => obj.Key, obj => obj.Value);
            List<Sprite> result = keyValuePairs.Values.ToList();

            return result;
        }
    }
}

