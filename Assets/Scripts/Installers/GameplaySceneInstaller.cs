using Buildings;
using LevelLogic;
using Player;
using Player.Counter;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [Header("Objects")]
        [SerializeField] private PrefabsHolder _prefabsHolder;
        [Header("Points Handler")]
        [SerializeField] private PointsHandler _pointsHandler;
        [SerializeField] private BuildingsPositionsHolder _positionsHolder;
        [Header("PlayerSettings")]
        [SerializeField] private TigerSettings _tigerSettings;
        [SerializeField] private PlayerTigersHolder _playerTigersHolder;
        [Header("BuildingSettings")] 
        [SerializeField] private BuildingHolder _buildingHolder;
        [SerializeField] private BuildingSettings _bankSettings;
        [SerializeField] private BuildingSettings _butcherShopSettings;
        
        public override void InstallBindings()
        {
            BindFabric();
            BindCounters();
            BindBuildings();
            BindTigerSettings();
        }

        private void BindBuildings()
        {
            _buildingHolder.Init(_butcherShopSettings, _bankSettings);
        }

        private void BindCounters()
        {
            Container.BindInterfacesAndSelfTo<MeatCounter>().AsSingle().WithArguments(0);
            Container.BindInterfacesAndSelfTo<MoneyCounter>().AsSingle().WithArguments(0);
        }

        private void BindTigerSettings()
        {
            Container.Bind<TigerSettings>().FromInstance(_tigerSettings).AsSingle();
            Container.Bind<PointsHandler>().FromInstance(_pointsHandler).AsSingle();
        }

        private void BindFabric()
        {
            Container.Bind<PrefabsHolder>().FromInstance(_prefabsHolder).AsSingle();
            Container.Bind<ObjectsFabric>().AsSingle();
        }
    }
}