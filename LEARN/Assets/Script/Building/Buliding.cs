using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
 public struct  requirment
 {
   public int electricity;

 }

public interface IBuilding
{

   // requirment necessary { get; set; }

    void LifeCycle();
    requirment Requirment();

}

public abstract class Building : MonoBehaviour
{

    protected static List<GameObject> allRequirmentHUD= new List<GameObject>();


    private void Update()
    {
        if (GameManager.instance.gamePlay == true)
        {
            LifeCycle();
        }
         if (allRequirmentHUD!=null)
            {
                foreach (var hud in allRequirmentHUD)
                {
                    hud.SetActive(GameManager.instance.gamePlay?true:false);
                }
            }
           
    }

    public abstract void LifeCycle();
   
}




