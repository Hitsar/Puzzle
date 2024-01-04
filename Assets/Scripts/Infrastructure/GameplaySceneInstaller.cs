using Zenject;
using UnityEngine;
using PuzzleBuilder;

namespace Infrastructure
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private MaxPuzzleArea _maxPuzzleArea;
        [SerializeField] private PuzzleArea _puzzleArea;
        public override void InstallBindings()
        {
            Container.Bind<MaxPuzzleArea>()
                .FromInstance(_maxPuzzleArea)
                .AsSingle();

            Container.Bind<PuzzleArea>()
                .FromInstance(_puzzleArea)
                .AsSingle();
        }
    }
}

