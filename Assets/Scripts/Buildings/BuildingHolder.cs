using System.Collections.Generic;
using System.Linq;
using LevelLogic;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class BuildingHolder : MonoBehaviour
    {
        private ObjectsFabric _fabric;
        private BuildingsPositionsHolder _positions;

        private List<ButcherShop> _butcherShops;
        private List<Bank> _banks;
        private BuildingSettings _butcherShopSettings;
        private BuildingSettings _bankSettings;

        [Inject]
        public void Constructor(ObjectsFabric objectsFabric, BuildingsPositionsHolder positionsHolder)
        {
            _fabric = objectsFabric;
            _positions = positionsHolder;
        }

        public void Init(BuildingSettings butcherShopSettings, BuildingSettings bankSettings)
        {
            _butcherShopSettings = butcherShopSettings;
            _bankSettings = bankSettings;
        }

        private void Start()
        {
            _butcherShops = new List<ButcherShop>();
            _banks = new List<Bank>();
            CreateBank(0);
            CreateButcherShop(0);
        }

        public bool IsBankMax(int maxBanks) => _banks.Count == maxBanks;
        
        public bool IsButchersMax(int maxButchersShops) => _butcherShops.Count == maxButchersShops;

        public void CreateButcherShop(int positionIndex)
        {
            ButcherShop butcherShop = _fabric.CreateButcherShop(_positions.ButchersShopPoints[positionIndex].position, _butcherShopSettings);
            butcherShop.Rotate(transform);
            _butcherShops.Add(butcherShop);
        }

        public void CreateBank(int positionIndex)
        {
            Bank bank = _fabric.CreateBank(_positions.BankPoints[positionIndex].position, _bankSettings);
            bank.Rotate(transform);
            _banks.Add(bank);
        }
    }
}