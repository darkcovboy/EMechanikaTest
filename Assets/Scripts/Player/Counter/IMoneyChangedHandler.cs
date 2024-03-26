using System;

namespace Player.Counter
{
    public interface IMoneyChangedHandler
    {
        event Action<int> OnMoneyChangedValue;
    }
}