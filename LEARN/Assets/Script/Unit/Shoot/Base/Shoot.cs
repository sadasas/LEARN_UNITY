
using UnityEngine.AI;
using UnityEngine;
using System;

public enum TypeShoot
{
    SNIPER,
    NORMAL
}

[Serializable]
public struct ShootSetting
{
    public TypeShoot typeShoot;
    [Header("Shoot")]
    [Range(0, 5)]
    public float timeReloadReset;
    [Tooltip("Sniper : betwen 15 and 45\n Normal : betwen 10-15")]
    [Range(10, 45)]
    public float distanceShoot;
    [Range(1, 5)]
    public float distanceBetweenShoot;
}
public abstract class Shoot : ScriptableObject
{
    public  ShootSetting setting;
   
    public abstract void Shooting(int lvl,Transform target, NavMeshAgent agent, Transform pointLauncher);
}
