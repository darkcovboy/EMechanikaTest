using Player.Counter;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class ButcherShop : Building
    {
        private MeatCounter _meatCounter;
        
        [Inject]
        public void Constructor(MeatCounter meatCounter)
        {
            _meatCounter = meatCounter;
        }
        
        protected override void EarnCurrency()
        {
            _meatCounter.Add(BuildingSettings.Currency);
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            
        }
    }
}