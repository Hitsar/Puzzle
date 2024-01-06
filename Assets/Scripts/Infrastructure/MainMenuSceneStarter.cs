using Saves;
using UnityEngine;
using Zenject;

public class MainMenuSceneStarter : MonoBehaviour
{
    private ProgressLoader _progressLoader;
    private LevelLinksHolder _levelLinksHolder;
    [Inject]
    public void Construct(ProgressLoader progressLoader, LevelLinksHolder levelLinksHolder)
    {
        _progressLoader = progressLoader;
        _levelLinksHolder = levelLinksHolder;
    }
    private void Start()
    {
        Debug.Log("Scene started");
        _levelLinksHolder.Init();
        _progressLoader.Load();
    }
}
