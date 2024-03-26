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
            CreateBank();
            CreateButcherShop();
        }

        private void CreateButcherShop()
        {
            ButcherShop butcherShop = _fabric.CreateButcherShop(_positions.ButchersShopPoints.First(), _butcherShopSettings);
            _butcherShops.Add(butcherShop);
        }

        private void CreateBank()
        {
            Bank bank = _fabric.CreateBank(_positions.BankPoints.First(), _bankSettings);
            _banks.Add(bank);
        }
    }
}