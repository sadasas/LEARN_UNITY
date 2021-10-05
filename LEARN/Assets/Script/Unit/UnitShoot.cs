using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitShoot :MonoBehaviour, IShoot
{
   [SerializeField] Rigidbody bulletPrefab;
   [SerializeField] Transform pointLauncher;


    NavMeshAgent agent;
    UnitEvent unitEvent;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unitEvent = GetComponent<UnitEvent>();
    }



    public void Shoot(int lvl)
    {
        switch (lvl)
        {
            case 1:
                ShortShoot();
                break;
            case 2:
                MediumShoot();
                break;
            case 3:
               LongShoot();
                break;
        }
      

    }


    Rigidbody ShortShoot()
    {
        Rigidbody _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.identity) as Rigidbody;
        _bullet.velocity = agent.transform.forward * 4 + agent.transform.up * 1;

        return _bullet;
    }
    Rigidbody MediumShoot()
    {
        Rigidbody _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.identity) as Rigidbody;
        _bullet.velocity = agent.transform.forward * 10 + agent.transform.up * 2;

        return _bullet;
    }

    Rigidbody LongShoot()
    {
        Rigidbody _bullet = Instantiate(bulletPrefab, pointLauncher.position, Quaternion.identity) as Rigidbody;
        _bullet.velocity = agent.transform.forward * 16 + agent.transform.up * 3;

        return _bullet;
    }







    public void Subscribe()
    {
        unitEvent.shootEvent += Shoot;
    }

    public void Unsubscribe()
    {
        unitEvent.shootEvent -= Shoot;
    }
}
