using SaveLoadSystem;
using UnityEngine;
using Zenject;

public class MainMenuSceneStarter : MonoBehaviour
{
    private LevelLoader _levelLoader;
    private MoneyLoader _moneyLoader;
    private LevelLinksHolder _levelLinksHolder;
    [Inject]
    public void Construct(LevelLoader levelLoader, LevelLinksHolder levelLinksHolder, MoneyLoader moneyLoader)
    {
        _levelLoader = levelLoader;
        _levelLinksHolder = levelLinksHolder;
        _moneyLoader = moneyLoader;
    }
    private void Start()
    {
        _levelLinksHolder.Init();
        _moneyLoader.LoadWallet();
        _levelLoader.Load();
    }
}
