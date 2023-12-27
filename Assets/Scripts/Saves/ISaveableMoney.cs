namespace Saves
{
    public interface ISaveableMoney
    {
        void Import(ProgressWallet progressWallet);
        ProgressWallet Export();
    }
}