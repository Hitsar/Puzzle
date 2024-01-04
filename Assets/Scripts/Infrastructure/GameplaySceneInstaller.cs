using Zenject;
using UnityEngine;
using PuzzleBuilder;

namespace Infrastructure
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private MaxPuzzleArea _maxPuzzleArea;
        public override void InstallBindings()
        {
            Container.Bind<MaxPuzzleArea>()
                .FromInstance(_maxPuzzleArea)
                .AsSingle();
        }
    }
}

