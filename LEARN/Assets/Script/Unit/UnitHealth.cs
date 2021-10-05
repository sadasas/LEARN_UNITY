
using UnityEngine;

public class UnitHealth : MonoBehaviour ,IHealth
{
    [SerializeField] UnitHealthScriptable health;

    public int CurrentHealth(int maxHealth)
    {
        if(maxHealth>0)
        {
            health.health = maxHealth;
        }

        if (health.health <= 0f)
        {
            Debug.Log("HEALTH :die");
            Destroy(gameObject);
        }
        return health.health;
    }

    public int Damage(int damage)
    {
        health.health -= damage;
        CurrentHealth(0);
        return damage;
    }

    public int Healing(int healthPlus)
    {
       return health.health += healthPlus;
    }

    public int MaxHealth()
    {
        return health.maxHealth;
    }
}
