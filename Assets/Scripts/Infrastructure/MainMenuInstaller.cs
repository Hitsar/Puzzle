using UnityEngine;
using Zenject;
using UnityEngine.Audio;
using Audio;
using UI;
using Config;
using SaveLoadSystem;
using Shop;

namespace Infrastructure
{
    public class MainMenuInstaller : MonoInstaller
    {
        [Header("Monobehaviours")]
        [SerializeField] private LevelLinksHolder _levelLinksHolder;
        [SerializeField] private PurchasedLevelsLoader _puchasedLevelsLoader;
        [Header("Audio")]
        [SerializeField] private AudioMixer _audioMixer;

        [Header("Mediators")]
        [SerializeField] private MetagameMediatorToUI _metagameMediatorToUI;
        [SerializeField] private MetagameMediatorToLogic _metagameMediatorToLogic;

        [Header("UI")]
        [SerializeField] private MusicToggle _musicToggle;
        [SerializeField] private SoundToggle _soundToggle;
        [SerializeField] private SettingsPanelAnimator _settingsPanelAnimator;
        [SerializeField] private MoneyDisplay _moneyDisplay;
        public override void InstallBindings()
        {
            ConsistentComponentsHolder holder = GameObject.Find("Holder").GetComponent<ConsistentComponentsHolder>();

            Container.Bind<MusicAudioSource>()
                .FromInstance(holder.MusicAudioSource)
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

            Container.Bind<LevelLinksHolder>()
                .FromInstance (_levelLinksHolder) 
                .AsSingle();

            Container.Bind<MoneyDisplay>()
                .FromInstance(_moneyDisplay)
                .AsSingle();

            Container.Bind<LevelLoader>()
                .To<LevelLoader>()
                .AsSingle();

            Container.Bind<PurchasedLevelsLoader>()
                .FromInstance(_puchasedLevelsLoader)
                .AsSingle();

            Container.Bind<LevelSaver>()
                .To<LevelSaver>()
                .AsSingle();
        }
    }
}

