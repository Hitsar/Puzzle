using Assets.Scripts.TagComponents.Audio;
using Config;
using Saves.SettingsSaveLoad;
using TagComponents.Audio;
using UnityEngine;

public class ConsistentComponentsHolder : MonoBehaviour
{
    [SerializeField] private SettingsHolder _settingsHolder;
    [SerializeField] private SettingsLoader _settingsLoader;
    [SerializeField] private MusicAudioSource _musicAudioSource;
    [SerializeField] private SoundAudioSource _soundAudioSource;

    public SettingsHolder SettingsHolder => _settingsHolder;
    public SettingsLoader SettingsLoader => _settingsLoader;
    public MusicAudioSource MusicAudioSource => _musicAudioSource;
    public SoundAudioSource SoundAudioSource => _soundAudioSource;
}
