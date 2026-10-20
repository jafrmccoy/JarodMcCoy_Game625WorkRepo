using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private Vector3 _spawnPos;
    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity);
        Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
        enemyComponent.Initialize(_enemyType);
    }
}
