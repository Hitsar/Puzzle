using Zenject;
using UnityEngine;
using PuzzleBuilder;

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
        }
    }
}

