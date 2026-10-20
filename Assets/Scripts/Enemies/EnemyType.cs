using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemyType", menuName = "ScriptableObjects/Enemy Type")]
public class EnemyType : ScriptableObject
{
    [SerializeField] private EnemyType _parentType;
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _attackDamage;
    [SerializeField] private Sprite _sprite;

    public EnemyType (EnemyType parent, string name, int maxHealth, int attackDamage, Sprite sprite)
    {
        _name = name;

        if (parent != null)
        {
            if (maxHealth == 0) { _health = parent.GetHealth(); }
            else { _health = maxHealth; }
            
            if (attackDamage == 0) { _attackDamage = parent.GetAttackDamage(); }
            else { _attackDamage = attackDamage; }
            
            if (sprite == null) { _sprite = parent.GetSprite(); }
            else { _sprite = sprite; }
        }
    }

    public string GetName() { return _name; }
    public int GetHealth()
    {
        if (_parentType != null &&  _health == 0) return _parentType.GetHealth();
        else return _health;
    }
    public int GetAttackDamage()
    {
        if (_parentType != null && _attackDamage == 0) return _parentType.GetAttackDamage();
        else return _attackDamage;
    }
    public Sprite GetSprite()
    {
        if (_parentType != null && _sprite == null) return _parentType.GetSprite();
        else return _sprite;
    }
}
