using Saves.SettingsSaveLoad;
using TagComponents.Audio;
using UnityEngine;
using Zenject;

public class AppStarter : MonoBehaviour
{
    private SettingsLoader _settingsLoader;
    private MusicAudioSource _musicAudioSource;
    [Inject]
    public void Construct(SettingsLoader settingsLoader, MusicAudioSource musicAudioSource)
    {
        _settingsLoader = settingsLoader;
        _musicAudioSource = musicAudioSource;
    }
    private void Start()
    {
        _settingsLoader.LoadSettings();
    }
}
