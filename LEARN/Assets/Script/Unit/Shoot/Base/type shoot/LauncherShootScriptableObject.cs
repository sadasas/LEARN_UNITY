
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "TypeShoot", menuName = "Shoot/Type Shoot/Launcher Shoot")]
public class LauncherShootScriptableObject : Shoot
{
  
    [Space(20)]
    [Header("lAUNCHER SHOOT")]
    [SerializeField] private GameObject bulletPrefab;




    public override void Shooting(int lvl, Transform target, NavMeshAgent agent, Transform pointLauncher)
    {
        ShortShoot(target,agent,pointLauncher);
    }

    GameObject ShortShoot(Transform target, NavMeshAgent agent, Transform pointLauncher)
    {
       
        GameObject _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.LookRotation(pointLauncher.transform.up, pointLauncher.transform.forward)) ;

        _bullet.GetComponent<RocketController>().target = target;
       
        return _bullet;
    }
   
}
