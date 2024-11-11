using UnityEngine;

namespace ZooWorld.Animals.Components.Abstraction
{
    public interface ICollisionBehavior: IAnimalBehavior
    {
        void HandleCollision(Collision collision);
    }
}