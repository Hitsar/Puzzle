using Zenject;
using UnityEngine;
using PuzzleBuilder;
using Puzzles;
using Audio;

namespace Infrastructure
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [Header("ScriptableObjects")]
        [SerializeField] private PuzzlesDataSO _puzzleDataSO;

        [Header("Monobehaviours")]
        [SerializeField] private MaxPuzzleArea _maxPuzzleArea;
        [SerializeField] private PuzzleArea _puzzleArea;
        [SerializeField] private PiecesSpawner _peicesSpawner;
        [SerializeField] private WinAudio _winAudio;
        [SerializeField] private AudioInPlace _audioInPlace;

        [Header("UI")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private LayoutPuzzleBar _puzzleBar;
        [SerializeField] private PuzzleDump _puzzleDump;
        public override void InstallBindings()
        {
            Container.Bind<MaxPuzzleArea>()
                .FromInstance(_maxPuzzleArea)
                .AsSingle();

            Container.Bind<PuzzleArea>()
                .FromInstance(_puzzleArea)
                .AsSingle();

            Container.Bind<PuzzleSizeQualifier>()
                .To<PuzzleSizeQualifier>()
                .AsSingle();

            Container.Bind<PuzzlesDataSO>()
                .FromInstance(_puzzleDataSO) 
                .AsSingle();

            Container.Bind<PuzzleResizer>()
                .To<PuzzleResizer>()
                .AsSingle();

            Container.Bind<PiecesSpawner>()
                .FromInstance(_peicesSpawner) 
                .AsSingle();

            Container.Bind<PuzzlePlacer>()
                .To<PuzzlePlacer>()
                .AsSingle();

            Container.Bind<Canvas>()
                .FromInstance(_canvas)
                .AsSingle();

            Container.Bind<PuzzleVfx>()
                .To<PuzzleVfx>()
                .AsTransient();

            Container.Bind<LayoutPuzzleBar>()
                .FromInstance(_puzzleBar)
                .AsSingle();

            Container.Bind<WinAudio>()
                .FromInstance(_winAudio) 
                .AsSingle();

            Container.Bind<GameStateObserver>()
                .To<GameStateObserver>()
                .AsSingle();

            Container.Bind<AudioInPlace>()
                .FromInstance(_audioInPlace) 
                .AsSingle();

            Container.Bind<PuzzleDump>()
                .FromInstance(_puzzleDump)
                .AsSingle();

            Container.Bind<SketchPieceFactory>()
                .To<SketchPieceFactory>()
                .AsSingle();

            Container.Bind<InteractivePuzzleFactory>()
                .To<InteractivePuzzleFactory>()
                .AsSingle();
        }
    }
}

