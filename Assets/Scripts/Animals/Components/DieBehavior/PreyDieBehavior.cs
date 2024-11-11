using UnityEngine;
using Zenject;
using ZooWorld.Animals.Components.Abstraction;
using ZooWorld.Animals.Components.CollisionBehavior;
using ZooWorld.Animals.Events;
using ZooWorld.EventBus.Abstraction;

namespace ZooWorld.Animals.Components.DieBehavior
{
    public class PreyDieBehavior : MonoBehaviour, IDieBehavior, IInitializableBehavior
    {
        private Animal _animal;
        private IEventBus _eventBus;

        public bool IsDie { get; private set; }

        [SerializeField] private float _explosionForce = 50f;
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private float _partLifeTime = 3f;

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Initialize(Animal animal)
        {
            _animal = animal;
        }

        
        public void Die(Animal killer)
        {
            _eventBus.Publish(new PreyDieEvent());
            IsDie = true;

            if (killer.GetAnimalComponent<PreyCollisionBehavior>() != null)
                FlyApart();
            else if (killer.GetAnimalComponent<PredatorCollisionBehavior>() != null)
                Destroy(_animal.gameObject);
        }
        
        private void FlyApart()
        {
            var meshRenderers = _animal.GetComponentsInChildren<MeshRenderer>();

            foreach (var renderer in meshRenderers)
            {
                var part = renderer.gameObject;
                
                part.transform.parent = null;
                
                if (!part.TryGetComponent<Rigidbody>(out var rb))
                {
                    rb = part.AddComponent<Rigidbody>();
                }
                
                if (!part.TryGetComponent<Collider>(out _))
                {
                    var meshCollider = part.AddComponent<MeshCollider>();
                    meshCollider.convex = true;
                }
                
                rb.AddExplosionForce(_explosionForce, _animal.transform.position, _explosionRadius);
                
                Destroy(part, _partLifeTime);
            }

            Destroy(_animal.gameObject);
        }
    }
}