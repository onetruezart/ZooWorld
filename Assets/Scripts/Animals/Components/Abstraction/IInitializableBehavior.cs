namespace ZooWorld.Animals.Components.Abstraction
{
    public interface IInitializableBehavior : IAnimalBehavior
    {
        void Initialize(Animal animal);
    }
}