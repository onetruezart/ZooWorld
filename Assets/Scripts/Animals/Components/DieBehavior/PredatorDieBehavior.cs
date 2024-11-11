using UnityEngine;
using Zenject;
using ZooWorld.Animals.Components.Abstraction;
using ZooWorld.Animals.Events;
using ZooWorld.EventBus.Abstraction;

namespace ZooWorld.Animals.Components.DieBehavior
{
    public class PredatorDieBehavior : MonoBehaviour, IDieBehavior, IInitializableBehavior
    {
        private Animal _animal;
        private IEventBus _eventBus;
        
        public bool IsDie { get; private set; }
        
        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Initialize(Animal animal)
        {
            _animal = animal;
        }
        
        public void Die(Animal _)
        {
            IsDie = true;
            _eventBus.Publish(new PredatorDieEvent());
            Destroy(_animal.gameObject);
        }
    }
}