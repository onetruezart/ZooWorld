using Zenject;
using ZooWorld.AnimalSpawner.Infrastructure;
using ZooWorld.EventBus.Infrastructure;
using ZooWorld.UI.DeathCounter.Infrastructure;
using ZooWorld.UI.MessageDisplay.Infrastructure;

namespace ZooWorld.Core.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            EventBusInstaller.Install(Container);
            AnimalSpawnerInstaller.Install(Container);
            DeathCounterInstaller.Install(Container);
            MessageDisplayInstaller.Install(Container);
        }
    }
}
