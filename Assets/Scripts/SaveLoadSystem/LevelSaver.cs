using SaveLoadSystem;
using Shop;
using UnityEngine;
using Zenject;

public class LevelSaver
{
    private PurchasedLevelsLoader _purchasedLevelsLoader;
    private LocalStorage _localStorage;
    [Inject]
    public LevelSaver(PurchasedLevelsLoader purchasedLevelsLoader, LocalStorage localStorage)
    {
        _purchasedLevelsLoader = purchasedLevelsLoader;
        _localStorage = localStorage;
    }

    public void Save()
    {
        var saveProfile = MakeSaveAsset();
        _localStorage.SaveProgress(saveProfile);
        Debug.Log("Game Saved");
    }

    private ProgressAsset MakeSaveAsset()
    {
        var saveProfile = new ProgressAsset();
        ExportLevelsTo(saveProfile);
        return saveProfile;
    }

    private void ExportLevelsTo(ProgressAsset saveProfile) => saveProfile.ProgressLevels = _purchasedLevelsLoader.Export();
}
