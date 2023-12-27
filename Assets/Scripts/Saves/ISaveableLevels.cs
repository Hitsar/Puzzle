namespace Saves
{
    public interface ISaveableLevels
    {
        void Import(ProgressLevels progressWallet);
        ProgressLevels Export();
    }
}