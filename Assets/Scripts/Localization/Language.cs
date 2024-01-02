using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Localization
{
    public class Language : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern string GetLang();
        
        public static LanguageTags CurrentLanguage;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            CurrentLanguage = (LanguageTags)Enum.Parse(typeof(LanguageTags), GetLang(), true);
        }
    }

    public enum LanguageTags
    {
        en,
        ru,
        es,
        tr,
        de
    }
}