namespace SaveLoadSystem
{
    public interface ISaveableLevels
    {
        void Import(ProgressLevels progressWallet);
        ProgressLevels Export();
    }
}