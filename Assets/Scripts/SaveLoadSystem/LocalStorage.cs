using System.Runtime.InteropServices;
using UnityEngine;

namespace Saves
{
    public class LocalStorage
    {
        private const string MUSIC_MUTED_KEY = "MusicMuted";
        private const string VOICES_MUTED_KEY = "VoicesMuted";
        private const string PROGRESS_KEY = "Progress";

        [DllImport("__Internal")]
        private static extern void SaveExtern(string date);

        [DllImport("__Internal")]
        private static extern void LoadExtern();
        
        public static void SaveProgress(ProgressAsset progress)
        {
            var progressJson = JsonUtility.ToJson(progress);
            SaveExtern(progressJson);
        }

        public static void LoadProgress() => LoadExtern();

        public static void DeleteProgress()
        {
            PlayerPrefs.DeleteKey(PROGRESS_KEY);
        }

        public static void SaveSettings(SettingsData settings)
        {
            PlayerPrefs.SetInt(MUSIC_MUTED_KEY, (bool)settings.MusicMuted ? 1 : 0);
            PlayerPrefs.SetInt(VOICES_MUTED_KEY, (bool)settings.VoicesMuted ? 1 : 0);
            PlayerPrefs.Save();
        }

        public static SettingsData LoadSettings()
        {
            SettingsData settings = new SettingsData();
            if (PlayerPrefs.HasKey(MUSIC_MUTED_KEY))
                settings.MusicMuted = PlayerPrefs.GetInt(MUSIC_MUTED_KEY) == 1;
            if (PlayerPrefs.HasKey(VOICES_MUTED_KEY))
                settings.VoicesMuted = PlayerPrefs.GetInt(VOICES_MUTED_KEY) == 1;
            return settings;

        }
    }
}