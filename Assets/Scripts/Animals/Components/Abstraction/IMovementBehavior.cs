using UnityEngine;

namespace ZooWorld.Animals.Components.Abstraction
{
    public interface IMovementBehavior : IAnimalBehavior
    {
        void SetDirection(Vector3 direction);

        void CalcDirection();

        void Move();
    }
}