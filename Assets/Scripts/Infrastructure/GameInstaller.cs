using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header("UI")]
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundToggle;

        public override void InstallBindings()
        {
            
        }
    }
}

