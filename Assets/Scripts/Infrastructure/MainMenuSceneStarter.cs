using Localization;
using SaveLoadSystem;
using UnityEngine;
using Zenject;

public class MainMenuSceneStarter : MonoBehaviour
{
    private LevelLoader _levelLoader;
    private MoneyLoader _moneyLoader;
    private LevelLinksHolder _levelLinksHolder;
    private Language _language;
    [Inject]
    public void Construct(LevelLoader levelLoader, LevelLinksHolder levelLinksHolder, MoneyLoader moneyLoader, Language language)
    {
        _levelLoader = levelLoader;
        _levelLinksHolder = levelLinksHolder;
        _moneyLoader = moneyLoader;
        _language = language;
    }
    private void Start()
    {
        _language.Init();
        _levelLinksHolder.Init();
        _moneyLoader.LoadWallet();
        _levelLoader.Load();
    }
}
