using Player.Counter;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class Bank : Building
    {
        private MoneyCounter _moneyCounter;
        
        [Inject]
        public void Constructor(MoneyCounter moneyCounter)
        {
            _moneyCounter = moneyCounter;
        }
        
        protected override void EarnCurrency()
        {
            _moneyCounter.Add(BuildingSettings.Currency);
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            
        }
    }
}