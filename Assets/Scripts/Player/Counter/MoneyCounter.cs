using System;
using PersistentData;
using Zenject;

namespace Player.Counter
{
    public class MoneyCounter : ICounter, IMoneyChangedHandler, IInitializable
    {
        public event Action<int> OnMoneyChangedValue;
        private int Money { get; set; }

        private Progress _progress;

        public MoneyCounter(Progress progress)
        {
            _progress = progress;
            Money = _progress.ProgressData.MoneyCollected;
        }
        
        public void Add(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Money += currency;
            _progress.ProgressData.MoneyCollected = Money;
            OnMoneyChangedValue?.Invoke(Money);
        }

        public void TakeCurrency(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Money -= currency;
            _progress.ProgressData.MoneyCollected = Money;
            OnMoneyChangedValue?.Invoke(Money);
        }

        public bool IsEnough(int currency) => currency <= Money;
        public void Initialize()
        {
            OnMoneyChangedValue?.Invoke(Money);
        }
    }
}