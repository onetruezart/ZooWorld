using Zenject;
using ZooWorld.AnimalSpawner.Abstraction;
using ZooWorld.AnimalSpawner.Realization;

namespace ZooWorld.AnimalSpawner.Infrastructure
{
    public class AnimalSpawnerInstaller : Installer<AnimalSpawnerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Realization.AnimalSpawner>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimalSpawnManager>().AsSingle().NonLazy();
        }
    }
}