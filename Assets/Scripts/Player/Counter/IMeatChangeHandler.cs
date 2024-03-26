using System;

namespace Player.Counter
{
    public interface IMeatChangeHandler
    {
        event Action<int> OnMeatChangeValue;
    }
}