using UnityEngine;
using ZooWorld.Animals.Components.Abstraction;

namespace ZooWorld.Animals.Components.CollisionBehavior
{   
    public class PreyCollisionBehavior : MonoBehaviour, ICollisionBehavior, IInitializableBehavior
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

            if (otherAnimal.GetAnimalComponent<PreyCollisionBehavior>() == null)
                return;
            
            if(_animal.GetAnimalComponent<IDieBehavior>().IsDie || otherAnimal.GetAnimalComponent<IDieBehavior>().IsDie)
                return;
            
            otherAnimal.GetAnimalComponent<IDieBehavior>().Die(_animal);
            _animal.GetAnimalComponent<IDieBehavior>().Die(otherAnimal);
            Debug.Log("!@#");
            
        }
    }
}