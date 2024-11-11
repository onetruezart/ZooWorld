using Zenject;
using ZooWorld.UI.MessageDisplay.Abstraction;
using ZooWorld.UI.MessageDisplay.Realization;

namespace ZooWorld.UI.MessageDisplay.Infrastructure
{
    public class MessageDisplayInstaller : Installer<MessageDisplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MessageDisplayView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<MessageDisplayController>().AsSingle();
        }
    }
}