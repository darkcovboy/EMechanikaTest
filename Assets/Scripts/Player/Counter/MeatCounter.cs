using System;
using PersistentData;
using Zenject;

namespace Player.Counter
{
    public class MeatCounter : ICounter, IMeatChangeHandler, IInitializable
    {
        public event Action<int> OnMeatChangeValue;
        private int Meat { get; set; }

        private readonly Progress _progress;

        public MeatCounter(Progress progress)
        {
            _progress = progress;
            Meat = _progress.ProgressData.MeatCollected;
        }
        
        public void Add(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Meat += currency;
            _progress.ProgressData.MeatCollected = Meat;
            OnMeatChangeValue?.Invoke(Meat);
        }

        public void TakeCurrency(int currency)
        {
            if(currency <= 0)
                throw new ArgumentException(nameof(currency));

            Meat -= currency;
            _progress.ProgressData.MeatCollected = Meat;
            OnMeatChangeValue?.Invoke(Meat);
        }

        public bool IsEnough(int currency) => currency <= Meat;
        public void Initialize()
        {
            OnMeatChangeValue?.Invoke(Meat);
        }
    }
}