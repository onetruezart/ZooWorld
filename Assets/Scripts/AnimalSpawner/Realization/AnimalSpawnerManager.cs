using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZooWorld.AnimalSpawner.Abstraction;

namespace ZooWorld.AnimalSpawner.Realization
{
    public class AnimalSpawnManager : IAnimalSpawnManager, IInitializable, IDisposable
    {
        private readonly IAnimalSpawner _animalSpawner;
        private CancellationTokenSource _cancellationTokenSource;

        private readonly float _minSpawnInterval = 1f;
        private readonly float _maxSpawnInterval = 2f;

        [Inject]
        public AnimalSpawnManager(IAnimalSpawner animalSpawner)
        {
            _animalSpawner = animalSpawner;
        }

        public void Initialize()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            SpawnAnimalsAsync(_cancellationTokenSource.Token).Forget();
        }

        public void StopSpawning()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private async UniTaskVoid SpawnAnimalsAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    _animalSpawner.SpawnRandomAnimal();
                    float delay = UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval);
                    await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                
            }
        }

        public void Dispose()
        {
            StopSpawning();
        }
    }
}