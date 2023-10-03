using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public static AsteroidSpawner Instance { get; private set; }

    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private float _spawnXMin, _spawnXMax;
    [SerializeField] private float _spawnTimeMin, _spawnTimeMax;
    private float _timeSinceLastSpawned = 0;
    private float _currentSpawnRate;

    private Queue<Asteroid> _asteroids = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _currentSpawnRate = ReturnRandomSpawnRate();
    }

    private void Update()
    {
        _timeSinceLastSpawned += Time.deltaTime;

        if (_timeSinceLastSpawned >= _currentSpawnRate)
        {
            _timeSinceLastSpawned = 0;
            _currentSpawnRate = ReturnRandomSpawnRate();
            if (_asteroids.Count <= 0)
            {
                Instantiate(_asteroidPrefab, ReturnRandomSpawnPosition(), Quaternion.identity);
                return;
            }
            Asteroid instance = _asteroids.Dequeue();
            instance.gameObject.SetActive(true);
            instance.transform.position = ReturnRandomSpawnPosition();
        }
    }

    private float ReturnRandomSpawnRate()
    {
        return Random.Range(_spawnTimeMin, _spawnTimeMax);
    }

    private Vector2 ReturnRandomSpawnPosition()
    {
        return new Vector2(Random.Range(_spawnXMin, _spawnXMax), transform.position.y);
    }

    public void ReturnToPool(Asteroid asteroid)
    {
        _asteroids.Enqueue(asteroid);
    }
}
