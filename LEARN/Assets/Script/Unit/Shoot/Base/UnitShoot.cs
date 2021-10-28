


using UnityEngine;
using UnityEngine.AI;


/*
 * 
 TODO : Create varian type shoot to make game look advance
 
 */
public class UnitShoot :MonoBehaviour
{
    [SerializeField] Shoot typeShoot;
    UnitEvent UEvent;
    NavMeshAgent UAgent;
    [SerializeField] Transform pointLauncher;
   


    private void Update()
    {
        Target();
       
    }
    private void OnEnable()
    {
        UEvent = GetComponent<UnitEvent>();
        UAgent = GetComponent<NavMeshAgent>();


        UEvent.shootEvent += Shoot;
      
    }

    void Shoot(int lvl)
    {
        typeShoot.Shooting(lvl,Target(), UAgent, pointLauncher);
    }

    private void OnDisable()
    {
        UEvent.shootEvent -= Shoot;
    }


    
   
    Transform Target()
    {
      Transform _target =  this.gameObject.GetComponent<Brain>().target;
       
        if (_target!=null)
        {
            if (_target.CompareTag("Player"))
            {

                return _target;
            }
        }

      

        return _target=null;
    }

}
