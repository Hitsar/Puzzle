using Zenject;
using UnityEngine;
using PuzzleBuilder;
using Puzzles;

namespace Infrastructure
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [Header("ScriptableObjects")]
        [SerializeField] private PuzzlesDataSO _puzzleDataSO;

        [Header("Monobehaviours")]
        [SerializeField] private MaxPuzzleArea _maxPuzzleArea;
        [SerializeField] private PuzzleArea _puzzleArea;
        [SerializeField] private PuzzleResizer _puzzleResizer;
        [SerializeField] private PiecesSpawner _peicesSpawner;

        [Header("UI")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private LayoutPuzzleBar _puzzleBar;
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

            Container.Bind<ConvexSizeCalculator>()
                .To<ConvexSizeCalculator>()
                .AsSingle();

            Container.Bind<PuzzleResizer>()
                .FromInstance(_puzzleResizer) 
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
        }
    }
}

