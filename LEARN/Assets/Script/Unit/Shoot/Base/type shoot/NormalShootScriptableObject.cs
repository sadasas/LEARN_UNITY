
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "TypeShoot",menuName ="Shoot/Type Shoot/Normal Shoot")]
public  class NormalShootScriptableObject :  Shoot
{
    
   
    [Space(20)]
    [Header("NORMAL SHOOT")]
    [SerializeField] private Rigidbody bulletPrefab;

    [Space(10)]
    [SerializeField] float velocityForward;
    [SerializeField] float velocityUpward;
    [SerializeField] float plusVelocityForward;
    [SerializeField] float plusVelocityUpward;


  
    public override void Shooting(int lvl, Transform target, NavMeshAgent agent, Transform pointLauncher)
    {
        switch (lvl)
        {
            case 1:
                ShortShoot( target,  agent,  pointLauncher);
                break;
            case 2:
                MediumShoot(target, agent, pointLauncher);
                break;
            case 3:
                LongShoot(target, agent, pointLauncher);
                break;
        }
    }
    Rigidbody ShortShoot(Transform target, NavMeshAgent agent, Transform pointLauncher)
    {
        Rigidbody _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.identity) as Rigidbody;
        _bullet.velocity = agent.transform.forward * velocityForward + agent.transform.up * velocityUpward;

        return _bullet;
    }
    Rigidbody MediumShoot(Transform target, NavMeshAgent agent, Transform pointLauncher)
    {
        Rigidbody _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.identity) as Rigidbody;
        _bullet.velocity = agent.transform.forward * (velocityForward + plusVelocityForward) + agent.transform.up * (velocityUpward + plusVelocityUpward);

        return _bullet;
    }

    Rigidbody LongShoot(Transform target, NavMeshAgent agent, Transform pointLauncher)
    {
        Rigidbody _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.identity) as Rigidbody;
        _bullet.velocity = agent.transform.forward * (velocityForward + plusVelocityForward * 2) + agent.transform.up * (velocityUpward + plusVelocityUpward * 2);

        return _bullet;
    }
   
  
}
