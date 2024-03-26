using Buildings;
using LevelLogic;
using Loader;
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
            BindLoader();
            BindFabric();
            BindCounters();
            BindBuildings();
            BindTigerSettings();
        }

        private void BindLoader()
        {
            //I don't like solutions like that but we know that everywhere SceneLoader is single, so it's okay 
            Container.Bind<SceneLoader>().FromInstance(FindObjectOfType<SceneLoader>()).AsSingle();
        }

        private void BindBuildings()
        {
            Container.Bind<BuildingsPositionsHolder>().FromInstance(_positionsHolder).AsSingle();
            _buildingHolder.Init(_butcherShopSettings, _bankSettings);
            Container.Bind<BuildingHolder>().FromInstance(_buildingHolder).AsSingle();
        }

        private void BindCounters()
        {
            Container.BindInterfacesAndSelfTo<MeatCounter>().AsSingle().WithArguments(1000);
            Container.BindInterfacesAndSelfTo<MoneyCounter>().AsSingle().WithArguments(1000);
        }

        private void BindTigerSettings()
        {
            Container.Bind<PlayerTigersHolder>().FromInstance(_playerTigersHolder).AsSingle();
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