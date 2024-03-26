using Player.Counter;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class ButcherShop : Building
    {
        private MeatCounter _meatCounter;
        private BuildingSettings _buildingSettings;
        
        [Inject]
        public void Constructor(MeatCounter meatCounter, BuildingSettings buildingSettings)
        {
            _meatCounter = meatCounter;
            _buildingSettings = buildingSettings;
        }
        
        protected override void EarnCurrency()
        {
            _meatCounter.Add(_buildingSettings.Currency);
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            
        }
    }
}