using SaveLoadSystem.SettingsSaveLoad;
using TagComponents.Audio;
using UnityEditor;
using UnityEngine;
using Zenject;
using SaveLoadSystem;

public class AppStarter : MonoBehaviour
{
    private SettingsLoader _settingsLoader;
    
    [Inject]
    public void Construct(SettingsLoader settingsLoader)
    {
        _settingsLoader = settingsLoader;
    }
    private void Start()
    {
        Debug.Log("App started");
        _settingsLoader.LoadSettings();
    }
}
