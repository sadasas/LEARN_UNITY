
using UnityEngine.AI;
using UnityEngine;

public abstract class Shoot : ScriptableObject
{
  
    public abstract void Shooting(int lvl,Transform target, NavMeshAgent agent, Transform pointLauncher);
}
