using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SDK
{
    public class Language : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern string GetLang();
        
        [HideInInspector] public string CurrentLanguage;
        
        public static Language Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = null;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}