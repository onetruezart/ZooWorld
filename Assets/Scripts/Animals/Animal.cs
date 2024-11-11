using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZooWorld.Animals.Components.Abstraction;

namespace ZooWorld.Animals
{
    public class Animal : MonoBehaviour
    {
        private readonly List<IAnimalBehavior> _components = new ();

        public T GetAnimalComponent<T>() where T : class, IAnimalBehavior
        {
            return _components.FirstOrDefault(x => x is T) as T;
        }

        private void Awake()
        {
            var components = GetComponents<IAnimalBehavior>();

            foreach (var component in components)
            {
                AddAnimalComponent(component);
            }
        }

        private void AddAnimalComponent<T>(T component) where T : IAnimalBehavior
        {
            _components.Add(component);

            if (component is IInitializableBehavior initializable)
            {
                initializable.Initialize(this);
            }
        }

        private void Update()
        {
            foreach (var component in _components)
            {
                if (component is IUpdateBehavior updatable)
                {
                    updatable.Update();
                }
            }
            foreach (var component in _components)
            {
                if (component is IMovementBehavior movable)
                {
                    movable.CalcDirection();
                }
            }
            CheckBounds();
            foreach (var component in _components)
            {
                if (component is IMovementBehavior movable)
                {
                    movable.Move();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (var component in _components)
            {
                if (component is ICollisionBehavior collisionBehavior)
                {
                    collisionBehavior.HandleCollision(collision);
                }
            }
        }

        private void CheckBounds()
        {
            Vector3 position = transform.position;
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

            bool isOutOfBounds = viewportPosition.x < 0 || viewportPosition.x > 1 ||
                                 viewportPosition.y < 0 || viewportPosition.y > 1;
            
            if (isOutOfBounds)
            {
                foreach (var component in _components)
                {
                    if (component is IBoundaryExitBehavior boundaryExitBehavior)
                    {
                        boundaryExitBehavior.HandleBoundaryExit();
                    }
                }
            }
        }
    }
}