using Zenject;
using UnityEngine;
using Puzzles;

namespace PuzzleBuilder
{
    public class InteractivePuzzleFactory
    {
        private readonly DiContainer _diContainer;
        private const string _interactivePuzzleName = "InteractivePuzzle";
        private Object _interactivePuzzlePrefab;
        private PuzzleDump _puzzleDump;

        [Inject]
        public InteractivePuzzleFactory(DiContainer diContainer, PuzzleDump puzzleDump)
        {
            _diContainer = diContainer;
            _puzzleDump = puzzleDump;
        }

        public void Load()
        {
            _interactivePuzzlePrefab = Resources.Load(_interactivePuzzleName);
        }

        public InteractivePuzzle Create(Sprite newSprite, SketchPiece sketchPiece)
        {
            InteractivePuzzle newInteractivePuzzle = _diContainer.InstantiatePrefabForComponent<InteractivePuzzle>(_interactivePuzzlePrefab, _puzzleDump.transform);
            newInteractivePuzzle.Image.sprite = newSprite;
            newInteractivePuzzle.ConnectToSketchPiece(sketchPiece);
            return newInteractivePuzzle;
        }
    }
}