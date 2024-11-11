using Zenject;
using ZooWorld.UI.DeathCounter.Abstraction;
using ZooWorld.UI.DeathCounter.Models;
using ZooWorld.UI.DeathCounter.Realization;

namespace ZooWorld.UI.DeathCounter.Infrastructure
{
    public class DeathCounterInstaller : Installer<DeathCounterInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<DeathCounterModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathCounterView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathCounterPresenter>().AsSingle();
        }
    }
}