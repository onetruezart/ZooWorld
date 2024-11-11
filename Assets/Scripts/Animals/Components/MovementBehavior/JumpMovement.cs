using UnityEngine;
using ZooWorld.Animals.Components.Abstraction;

namespace ZooWorld.Animals.Components.MovementBehavior
{
    public class JumpMovement : MonoBehaviour, IMovementBehavior, IInitializableBehavior
    {
        private Animal _animal;
        private Rigidbody _rigidbody;
        private float _nextJumpTime;
        private Vector3 _jumpDirection;

        [SerializeField] private float _jumpInterval = 2f;
        [SerializeField] private float _jumpDistance = 5f; 

        public void Initialize(Animal animal)
        {
            _animal = animal;
            _rigidbody = _animal.GetComponent<Rigidbody>();

            _nextJumpTime = Time.time + _jumpInterval;
        }

        public void Move()
        {
            if (!(Time.time >= _nextJumpTime)) 
                return;
            
            Jump();
            _nextJumpTime = Time.time + _jumpInterval;
        }

        private void Jump()
        {
            Vector3 horizontalDirection = new Vector3(_jumpDirection.x, 0, _jumpDirection.z).normalized;
            
            float angle = 45f * Mathf.Deg2Rad;
            float gravity = Mathf.Abs(Physics.gravity.y);
            
            float initialSpeed = Mathf.Sqrt((_jumpDistance * gravity) / Mathf.Sin(2 * angle));
            
            float vx = initialSpeed * Mathf.Cos(angle);
            float vy = initialSpeed * Mathf.Sin(angle);

            Vector3 velocity = horizontalDirection * vx + Vector3.up * vy;
            
            _animal.transform.forward = _jumpDirection;
            _rigidbody.velocity = velocity;
        }

        public void SetDirection(Vector3 direction)
        {
            _jumpDirection = direction;
        }

        public void CalcDirection()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            _jumpDirection = new Vector3(randomDirection.x, 0f, randomDirection.y);
        }
    }
}