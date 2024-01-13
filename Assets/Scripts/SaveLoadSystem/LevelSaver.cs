using SaveLoadSystem;
using Shop;
using UnityEngine;
using Zenject;

public class LevelSaver
{
    private PurchasedLevelsLoader _purchasedLevelsLoader;

    [Inject]
    public LevelSaver(PurchasedLevelsLoader purchasedLevelsLoader)
    {
        _purchasedLevelsLoader = purchasedLevelsLoader;
    }

    public void Save()
    {
        var saveProfile = MakeSaveAsset();
        LocalStorage.SaveProgress(saveProfile);
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
