using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyType _enemyType;
    [SerializeField] private int _currentHealth;

    public void Initialize (EnemyType enemyType)
    {
        _enemyType = enemyType;
        _currentHealth = _enemyType.GetHealth();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr) { sr.sprite = _enemyType.GetSprite(); }

        transform.name = _enemyType.GetName();
    }
}
