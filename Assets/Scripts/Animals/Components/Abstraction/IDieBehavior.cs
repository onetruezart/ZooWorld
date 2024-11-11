namespace ZooWorld.Animals.Components.Abstraction
{
    public interface IDieBehavior: IAnimalBehavior
    {
        public bool IsDie { get; }
        void Die(Animal killer);
    }
}