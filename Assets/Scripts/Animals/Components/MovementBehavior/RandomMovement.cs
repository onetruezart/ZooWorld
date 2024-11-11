using UnityEngine;
using ZooWorld.Animals.Components.Abstraction;

namespace ZooWorld.Animals.Components.MovementBehavior
{
    public class RandomMovement : MonoBehaviour, IMovementBehavior, IInitializableBehavior
    {
        private Animal _animal;
        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private float _nextNewDirTime;
        
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _newDirMinTime = 2f;
        [SerializeField] private float _newDirMaxTime = 5f;

        public void Initialize(Animal animal)
        {
            _animal = animal;
            _rigidbody = _animal.GetComponent<Rigidbody>();
        }
        
        public void Move()
        {
            _animal.transform.forward = _direction;
            _rigidbody.MovePosition(_animal.transform.position + _direction.normalized * (_moveSpeed * Time.deltaTime));
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void CalcDirection()
        {
            if (!(Time.time >= _nextNewDirTime)) 
                return;
            _direction = Random.insideUnitSphere;
            _direction.y = 0f; 
           
            _nextNewDirTime = Time.time + Random.Range(_newDirMinTime, _newDirMaxTime);
           
        }
    }
}