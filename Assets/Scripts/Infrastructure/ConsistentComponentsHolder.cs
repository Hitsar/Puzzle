using Config;
using SaveLoadSystem;
using Audio;
using UnityEngine;

public class ConsistentComponentsHolder : MonoBehaviour
{
    [SerializeField] private SettingsHolder _settingsHolder;
    [SerializeField] private SettingsLoader _settingsLoader;
    [SerializeField] private MusicAudioSource _musicAudioSource;

    public SettingsHolder SettingsHolder => _settingsHolder;
    public SettingsLoader SettingsLoader => _settingsLoader;
    public MusicAudioSource MusicAudioSource => _musicAudioSource;
}
