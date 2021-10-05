
using UnityEngine;


[CreateAssetMenu(fileName ="Unit/Health")]
public class UnitHealthScriptable : ScriptableObject
{
    public int health;
    public int maxHealth;

    private void OnEnable()
    {
        health = maxHealth;
    }

}


