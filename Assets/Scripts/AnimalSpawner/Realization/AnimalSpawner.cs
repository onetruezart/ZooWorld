using UnityEngine;
using Zenject;
using ZooWorld.AnimalSpawner.Abstraction;

namespace ZooWorld.AnimalSpawner.Realization
{
    public class AnimalSpawner : MonoBehaviour, IAnimalSpawner
    {
        [SerializeField] private GameObject[] _animalsPrefabs;
        [SerializeField] private Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);

        private DiContainer _container;

        [Inject]
        public void Construct(DiContainer container)
        {
            _container = container;
        }

        public GameObject SpawnRandomAnimal()
        { 
            int randomValue = Random.Range(0, _animalsPrefabs.Length);
            return SpawnAnimal(_animalsPrefabs[randomValue]);
        }

        private GameObject SpawnAnimal(GameObject animalPrefab)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            return _container.InstantiatePrefab(animalPrefab, spawnPosition, Quaternion.identity, null);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                0f,
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
            );
            return randomPosition;
        }
    }
}