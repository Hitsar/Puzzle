namespace SaveLoadSystem
{
    public interface ISaveableMoney
    {
        void Import(int savedMoneyValue);
        ProgressWallet Export();
    }
}