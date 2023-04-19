using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float _minRate = 0.5f;
    [SerializeField] float _maxRate = 2f;
    [SerializeField] float _maxSpawnRate = 1.5f;
    [SerializeField] Vector2 _min;
    [SerializeField] Vector2 _max;
    [SerializeField] EnemyController[] _enemies;

    float _currentRate = 0f;
    int _length;

    void Start()
    {
        _length = _enemies.Length;
        RandomRate();
    }

    void Update()
    {
        _currentRate += Time.deltaTime;

        if (_currentRate > _maxSpawnRate)
        {
            RandomRate();
            Spawn();
        }
    }

    void Spawn()
    {
        float randomY = Random.Range(_min.y, _max.y);
        float randomX = Random.Range(_min.x, _max.x);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
        var enemy = Instantiate(_enemies[Random.Range(0, _length)], randomPosition, Quaternion.identity);
        enemy.transform.SetParent(this.transform);
    }

    private void RandomRate()
    {
        _currentRate = 0f;
        _maxSpawnRate = Random.Range(_minRate, _maxRate);
    }
}
