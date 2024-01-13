using Config;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class LocalStorage
    {
        private const string MUSIC_MUTED_KEY = "MusicMuted";
        private const string VOICES_MUTED_KEY = "VoicesMuted";
        private const string PROGRESS_KEY = "Progress";
        private const string MONEY_KEY = "Money";

        [Inject]
        public LocalStorage()
        {

        }

        public static void SaveProgress(ProgressAsset progress)
        {
            var progressJson = JsonUtility.ToJson(progress);
            PlayerPrefs.SetString(PROGRESS_KEY, progressJson);
            PlayerPrefs.Save();
        }

        public static void SaveMoney(int money)
        {
            PlayerPrefs.SetInt(MONEY_KEY, money);
            PlayerPrefs.Save();
        }
        
        public static ProgressAsset GetProgress()
        {
            var progressJson = PlayerPrefs.GetString(PROGRESS_KEY);
            if (progressJson == null)
                return null;
            var progress = JsonUtility.FromJson<ProgressAsset>(progressJson);
            return progress;
        }

        public static int GetMoneyValue()
        {
            return PlayerPrefs.GetInt(MONEY_KEY);
        }

        public static void DeleteProgress()
        {
            PlayerPrefs.DeleteKey(PROGRESS_KEY);
            PlayerPrefs.DeleteKey(MONEY_KEY);
        }
        
        public static void SaveSettings(SettingsHolder settingsHolder)
        {
            PlayerPrefs.SetInt(MUSIC_MUTED_KEY, (bool)settingsHolder.IsMusicMuted ? 1 : 0);
            PlayerPrefs.SetInt(VOICES_MUTED_KEY, (bool)settingsHolder.IsSoundMuted ? 1 : 0);
            PlayerPrefs.Save();
        }

        public static SettingsData LoadSettings()
        {
            var settings = new SettingsData();
            if (PlayerPrefs.HasKey(MUSIC_MUTED_KEY))
                settings.MusicMuted = PlayerPrefs.GetInt(MUSIC_MUTED_KEY) == 1;
            else
                settings.MusicMuted = false;
            if (PlayerPrefs.HasKey(VOICES_MUTED_KEY))
                settings.VoicesMuted = PlayerPrefs.GetInt(VOICES_MUTED_KEY) == 1;
            else
                settings.VoicesMuted = false;
            return settings;

        }
    }
}