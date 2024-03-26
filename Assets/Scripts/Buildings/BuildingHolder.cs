using System;
using System.Collections.Generic;
using System.Linq;
using LevelLogic;
using PersistentData;
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
        private Progress _progress;

        [Inject]
        public void Constructor(ObjectsFabric objectsFabric, BuildingsPositionsHolder positionsHolder, Progress progress)
        {
            _fabric = objectsFabric;
            _positions = positionsHolder;
            _progress = progress;
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
            Debug.Log(_progress.ProgressData.CountBanks);
            SpawnBanks();
            SpawnButchers();
        }

        private void SpawnBanks()
        {
            for (int i = 0; i < (_progress.ProgressData.CountBanks + 1); i++)
            {
                CreateBank(i, true);
            }
        }

        private void SpawnButchers()
        {
            for (int i = 0; i < _progress.ProgressData.CountButchers + 1; i++)
            {
                CreateButcherShop(i, true);
            }
        }

        public bool IsBankMax(int maxBanks) => _banks.Count == maxBanks;
        
        public bool IsButchersMax(int maxButchersShops) => _butcherShops.Count == maxButchersShops;

        public void CreateButcherShop(int positionIndex, bool isStartSpawn = false)
        {
            ButcherShop butcherShop = _fabric.CreateButcherShop(_positions.ButchersShopPoints[positionIndex].position, _butcherShopSettings);
            butcherShop.Rotate(transform);
            _butcherShops.Add(butcherShop);
            if(!isStartSpawn)
                _progress.ProgressData.CountButchers++;
            
        }

        public void CreateBank(int positionIndex, bool isStartSpawn = false)
        {
            Bank bank = _fabric.CreateBank(_positions.BankPoints[positionIndex].position, _bankSettings);
            bank.Rotate(transform);
            _banks.Add(bank);
            if(!isStartSpawn)
              _progress.ProgressData.CountBanks++;
        }
    }
}