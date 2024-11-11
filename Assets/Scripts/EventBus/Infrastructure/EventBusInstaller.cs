using Zenject;
using ZooWorld.EventBus.Abstraction;

namespace ZooWorld.EventBus.Infrastructure
{
    public class EventBusInstaller : Installer<EventBusInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEventBus>().To<Realization.EventBus>().AsSingle();
        }
    }
}