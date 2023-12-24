namespace YG
{
    public static class LanguageManager
    {
        public delegate void LanguageChangeHandler(string newLanguage);
        public static event LanguageChangeHandler OnLanguageChanged;

        public static void ChangeLanguage(string language) => OnLanguageChanged?.Invoke(language);
    }
}
