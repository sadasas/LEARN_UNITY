
using UnityEngine;

public class UnitHealth : MonoBehaviour ,IHealth
{
    [SerializeField] TypeHealthScriptable health;
    public  int _health;

    private void Awake()
    {
        _health = health.maxHealth;
    }
    public int CurrentHealth(int maxHealth)
    {
        if(maxHealth>health.maxHealth)
        {
            _health = maxHealth;
        }

        if (_health <= 0f)
        {
            Debug.Log("HEALTH :die");
            Destroy(gameObject);
        }
        return _health;
    }

    public int Damage(int damage)
    {
        _health -= damage;
        CurrentHealth(0);
        return damage;
    }

    public int Healing(int healthPlus)
    {
       return _health += healthPlus;
    }

    public int MaxHealth()
    {
        return health.maxHealth;
    }
}
