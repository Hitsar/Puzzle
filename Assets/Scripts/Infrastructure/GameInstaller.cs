using UnityEngine;
using Zenject;
using UnityEngine.Audio;
using TagComponents.Audio;
using Assets.Scripts.TagComponents.Audio;
using Audio;
using UI;
using Config;
using Saves.SettingsSaveLoad;
using UnityEngine.WSA;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Audio")]
        [SerializeField] private AudioMixer _audioMixer;

        [Header("Mediators")]
        [SerializeField] private MetagameMediatorToUI _metagameMediatorToUI;
        [SerializeField] private MetagameMediatorToLogic _metagameMediatorToLogic;

        [Header("UI")]
        [SerializeField] private MusicToggle _musicToggle;
        [SerializeField] private SoundToggle _soundToggle;
        [SerializeField] private SettingsPanelAnimator _settingsPanelAnimator;
        public override void InstallBindings()
        {
            ConsistentComponentsHolder holder = GameObject.Find("Holder").GetComponent<ConsistentComponentsHolder>();

            Container.Bind<MusicAudioSource>()
                .FromInstance(holder.MusicAudioSource)
                .AsSingle();

            Container.Bind<SoundAudioSource>()
                .FromInstance(holder.SoundAudioSource)
                .AsSingle();

            Container.Bind<SettingsHolder>()
                .FromInstance(holder.SettingsHolder)
                .AsSingle();

            Container.Bind<SettingsLoader>()
                .FromInstance(holder.SettingsLoader)
                .AsSingle();

            Container.Bind<MusicToggle>()
                .FromInstance(_musicToggle)
                .AsSingle();

            Container.Bind<SoundToggle>()
                .FromInstance(_soundToggle)
                .AsSingle();

            Container.Bind<AudioMixer>()
                .FromInstance(_audioMixer)
                .AsSingle();

            Container.Bind<AudioMuter>()
                .To<AudioMuter>()
                .AsSingle();

            Container.Bind<MetagameMediatorToUI>()
                .FromInstance(_metagameMediatorToUI)
                .AsSingle();

            Container.Bind<SettingsPanelAnimator>()
                .FromInstance(_settingsPanelAnimator) 
                .AsSingle();

            Container.Bind<MetagameMediatorToLogic>()
                .FromInstance(_metagameMediatorToLogic)
                .AsSingle();
        }
    }
}

