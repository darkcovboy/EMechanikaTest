namespace Player.Counter
{
    public interface ICounter
    {
        void Add(int currency);
        void TakeCurrency(int currency);
        bool IsEnough(int currency);
    }
}