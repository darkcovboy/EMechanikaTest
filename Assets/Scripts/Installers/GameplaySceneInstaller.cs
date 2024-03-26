using LevelLogic;
using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private TigerSettings _tigerSettings;
        [SerializeField] private PrefabsHolder _prefabsHolder;
        [SerializeField] private PointsHandler _pointsHandler;
        
        public override void InstallBindings()
        {
            BindFabric();
            BindTigerSettings();
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