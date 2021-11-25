using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

/// <summary>
/// lifecycle bulding when play mode 
/// </summary>
public class House : Building, IBuilding
{
    [SerializeField] float delay;
    [SerializeField] GameObject waterHUDPefab;
    [SerializeField] Transform parentHUD;


    GameObject currentRequired= null;


    [SerializeField]  requirment necessary;

    public override void LifeCycle()
    {
        
        Requirment();
    }
    public requirment Requirment()
    {
        //check if player have requirment or not
        if (!GameManager.instance.CheckAvailable(necessary)) RequireSomething();
        return necessary;
    }
   

    GameObject RequireSomething()
    {
        //if not have requirment popup will show and check if is colapse by name 
        if(currentRequired!=null)
        {
            if ( currentRequired.name.Contains(waterHUDPefab.name)) return currentRequired = null;
           // Debug.Log(currentRequired.GetInstanceID() + "     " + c.GetInstanceID());

        }
     
       // Debug.Log("Spawn");     
        currentRequired  = Instantiate(waterHUDPefab, parentHUD);
        currentRequired.transform.rotation = Camera.main.transform.rotation;
        allRequirmentHUD.Add(currentRequired);
        return currentRequired;


    }

   
}
