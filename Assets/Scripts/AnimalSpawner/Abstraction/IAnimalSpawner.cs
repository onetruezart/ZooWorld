using UnityEngine;
using Zenject.Asteroids;

namespace ZooWorld.AnimalSpawner.Abstraction
{
    public interface IAnimalSpawner
    {
        GameObject SpawnRandomAnimal();
    }
}