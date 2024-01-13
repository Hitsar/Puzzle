using Localization;
using SaveLoadSystem;
using Shop;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller<AppInstaller>
{
    [SerializeField] private MoneyDataSO _moneyDataSO;
    [SerializeField] private LocalizationDataSO _localizationDataSO;
    public override void InstallBindings()
    {
        Container.Bind<Wallet>()
            .To<Wallet>()
            .AsSingle();

        Container.Bind<MoneyLoader>()
            .To<MoneyLoader>()
            .AsSingle();

        Container.Bind<MoneyDataSO>()
            .FromInstance(_moneyDataSO)
            .AsSingle();

        Container.Bind<MoneySaver>()
            .To<MoneySaver>()
            .AsSingle();

        Container.Bind<LocalStorage>()
            .To<LocalStorage>()
            .AsSingle();

        Container.Bind<LocalizationDataSO>()
            .FromInstance(_localizationDataSO)
            .AsSingle();

        Container.Bind<Language>()
            .To<Language>()
            .AsSingle();
    }

}
