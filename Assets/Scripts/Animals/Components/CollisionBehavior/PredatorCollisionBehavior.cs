using UnityEngine;
using ZooWorld.Animals.Components.Abstraction;

namespace ZooWorld.Animals.Components.CollisionBehavior
{
    public class PredatorCollisionBehavior : MonoBehaviour, ICollisionBehavior, IInitializableBehavior
    {
        private Animal _animal;

        public void Initialize(Animal animal)
        {
            _animal = animal;
        }

        public void HandleCollision(Collision collision)
        {
            Animal otherAnimal = collision.gameObject.GetComponent<Animal>();
            
            if (otherAnimal == null) 
                return;
            
            if(_animal.GetAnimalComponent<IDieBehavior>().IsDie || otherAnimal.GetAnimalComponent<IDieBehavior>().IsDie)
                return;
            
            var eatingBehavior = _animal.GetAnimalComponent<IEatingBehavior>();
            
            if (otherAnimal.GetAnimalComponent<PreyCollisionBehavior>() != null)
            {
                eatingBehavior?.Eat(otherAnimal);
            }
            else if (otherAnimal.GetAnimalComponent<PredatorCollisionBehavior>() != null)
            {
                if (Random.value > 0.5f)
                {
                    otherAnimal.GetAnimalComponent<IEatingBehavior>().Eat(_animal);
                }
                else
                {
                    eatingBehavior?.Eat(otherAnimal);
                }
            }
        }
    }
}