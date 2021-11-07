


using UnityEngine;
using UnityEngine.AI;


/*
 * 
 TODO : Create varian type shoot to make game look advance
 
 */


public class UnitShoot :MonoBehaviour
{
    public Shoot typeShoot { get; set; }
    [SerializeField] Transform pointLauncher;



    UnitEvent UEvent;
    NavMeshAgent UAgent;
   


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

    private void OnDisable()
    {
        UEvent.shootEvent -= Shoot;
    }


    void Shoot(int lvl)
    {
        typeShoot.Shooting(lvl,Target(), UAgent, pointLauncher);
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
