using System;

namespace Player.Counter
{
    public class MoneyCounter : ICounter, IMoneyChangedHandler
    {
        public event Action<int> OnMoneyChangedValue;
        private int Money { get; set; }

        public MoneyCounter(int startValue)
        {
            Money = startValue;
        }
        
        public void Add(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Money += currency;
            OnMoneyChangedValue?.Invoke(Money);
        }

        public void TakeCurrency(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Money -= currency;
            OnMoneyChangedValue?.Invoke(Money);
        }

        public bool IsEnough(int currency) => currency <= Money;
    }
}