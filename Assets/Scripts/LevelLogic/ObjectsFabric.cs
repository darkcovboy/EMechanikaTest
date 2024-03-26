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

        public TigerMovement CreateTiger(Vector3 at)
        {
            var tiger = _diContainer.InstantiatePrefabForComponent<TigerMovement>(_prefabs.TigerPrefab, at, Quaternion.identity, null);
            return tiger;
        }

        public PlayerInput CreatePlayerInput() => _diContainer.InstantiatePrefabForComponent<PlayerInput>(_prefabs.PlayerInput);

        public Bank CreateBank(Vector3 at, BuildingSettings buildingSettings)
        {
            Bank bank = _diContainer.InstantiatePrefabForComponent<Bank>(_prefabs.BankPrefab, at, Quaternion.identity,
                null);
            bank.Init(buildingSettings);
            return bank;
        }
        
        public ButcherShop CreateButcherShop(Vector3 at, BuildingSettings buildingSettings)
        {
            ButcherShop butcherShop = _diContainer.InstantiatePrefabForComponent<ButcherShop>(_prefabs.ButcherShopPrefab,at, Quaternion.identity, null);
            butcherShop.Init(buildingSettings);
            return butcherShop;
        }
    }
}