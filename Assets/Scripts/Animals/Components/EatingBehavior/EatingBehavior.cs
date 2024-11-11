using UnityEngine;
using Zenject;
using ZooWorld.Animals.Components.Abstraction;
using ZooWorld.Animals.Events;
using ZooWorld.EventBus.Abstraction;

namespace ZooWorld.Animals.Components.EatingBehavior
{
    public class EatingBehavior : MonoBehaviour, IEatingBehavior, IInitializableBehavior
    {
        private Animal _animal;
        private IEventBus _eventBus;

        public void Initialize(Animal animal)
        {
            _animal = animal;
        }
        
        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Eat(Animal target)
        {
            _eventBus.Publish(new ShowMessageEvent("Tasty!", _animal.transform.position));
            target.GetAnimalComponent<IDieBehavior>().Die(_animal);
        }
    }
}