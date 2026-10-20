using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (EnemySpawner))]
public class TestEnemySpawner : MonoBehaviour
{
    [SerializeField] private InputActionReference _spawnButton;
    private EnemySpawner _enemySpawner;
    private void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
    }
    void Update()
    {
        if (_spawnButton.action.WasPressedThisFrame())
        {
            _enemySpawner.SpawnEnemy();
        }
    }
}
