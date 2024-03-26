using Buildings;
using Installers;
using Player;
using UnityEngine;
using Zenject;

namespace LevelLogic
{
    public class ObjectsFabric
    {
        private DiContainer _diContainer;
        private PrefabsHolder _prefabs;

        public ObjectsFabric(DiContainer container, PrefabsHolder prefabs)
        {
            _diContainer = container;
            _prefabs = prefabs;
        }

        public TigerMovement CreateTiger(Transform at)
        {
            var tiger = _diContainer.InstantiatePrefabForComponent<TigerMovement>(_prefabs.TigerPrefab, at);
            return tiger;
        }

        public PlayerInput CreatePlayerInput() => _diContainer.InstantiatePrefabForComponent<PlayerInput>(_prefabs.PlayerInput);

        public Bank CreateBank(Transform at, BuildingSettings buildingSettings)
        {
            Bank bank = _diContainer.InstantiatePrefabForComponent<Bank>(at);
            bank.Init(buildingSettings);
            return bank;
        }
        
        public ButcherShop CreateButcherShop(Transform at, BuildingSettings buildingSettings)
        {
            ButcherShop butcherShop = _diContainer.InstantiatePrefabForComponent<ButcherShop>(at);
            butcherShop.Init(buildingSettings);
            return butcherShop;
        }
    }
}