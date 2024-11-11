using UnityEngine;
using ZooWorld.Animals.Components.Abstraction;

namespace ZooWorld.Animals.Components.BoundaryExitBehavior
{
    public class ScreenBoundaryExitBehavior : MonoBehaviour, IBoundaryExitBehavior, IInitializableBehavior
    {
        private Animal _animal;

        public void Initialize(Animal animal)
        {
            _animal = animal;
        }

        public void HandleBoundaryExit()
        {
            var pos = _animal.transform.position;
            var dir = -new Vector3(pos.x, 0, pos.z).normalized;
            _animal.GetAnimalComponent<IMovementBehavior>().SetDirection(dir);
        }
    }
}