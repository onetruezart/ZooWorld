namespace ZooWorld.Animals.Components.Abstraction
{
    public interface IEatingBehavior : IAnimalBehavior
    {
        void Eat(Animal target);
    }
}