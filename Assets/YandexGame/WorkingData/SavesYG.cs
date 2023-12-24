
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int money;
        public bool[] openLevels = new bool[27];
        
        public SavesYG()
        {
            openLevels[0] = true;
        }
    }
}
