using Loader;
using PersistentData;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindProgress();
            BindLoader();
        }

        private void BindProgress()
        {
            Container.Bind<Progress>().AsSingle();
        }

        private void BindLoader()
        {
            Container.Bind<SceneLoader>().FromInstance(FindObjectOfType<SceneLoader>()).AsSingle();
        }
    }
}