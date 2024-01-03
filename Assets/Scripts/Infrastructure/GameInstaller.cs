using UnityEngine;
using Zenject;
using TagComponents.UI;
using UnityEngine.Audio;
using TagComponents.Audio;
using Assets.Scripts.TagComponents.Audio;
using Audio;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Audio")]
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private MusicAudioSource _musicAudioSource;
        [SerializeField] private SoundAudioSource _soundAudioSource;

        [Header("UI")]
        [SerializeField] private MusicToggle _musicToggle;
        [SerializeField] private SoundToggle _soundToggle;

        public override void InstallBindings()
        {
            Debug.Log("Bindings installed");

            Container.Bind<MusicToggle>()
                .FromInstance(_musicToggle)
                .AsSingle();

            Container.Bind<SoundToggle>()
                .FromInstance(_soundToggle)
                .AsSingle();

            Container.Bind<AudioMixer>()
                .FromInstance(_audioMixer)
                .AsSingle();

            Container.Bind<MusicAudioSource>()
                .FromInstance(_musicAudioSource)
                .AsSingle();

            Container.Bind<SoundAudioSource>()
                .FromInstance(_soundAudioSource)
                .AsSingle();

            Container.Bind<AudioMuter>()
                .To<AudioMuter>()
                .AsSingle()
                .NonLazy();
        }
    }
}

