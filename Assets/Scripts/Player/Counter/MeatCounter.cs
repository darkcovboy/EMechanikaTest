using System;

namespace Player.Counter
{
    public class MeatCounter : ICounter, IMeatChangeHandler
    {
        public event Action<int> OnMeatChangeValue;
        private int Meat { get; set; }

        public MeatCounter(int startValue)
        {
            Meat = startValue;
        }
        
        public void Add(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Meat += currency;
            OnMeatChangeValue?.Invoke(Meat);
        }

        public void TakeCurrency(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Meat -= currency;
            OnMeatChangeValue?.Invoke(Meat);
        }

        public bool IsEnough(int currency) => currency <= Meat;
    }
}