using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 MAKE ABSTRACT CLASS TO BE BASE OF ALL HUD MANAGER
 
 */
public class MenuManager : MonoBehaviour
{
   
    [SerializeField] GameObject[] HUD;
    [SerializeField] Transform HUDParent;
   

    GameObject currentHUD;

    private void Start()
    {
        currentHUD = Instantiate(HUD[0], this.transform);
        GameEvent.instance.SwitchHUD += Switch;
    }



    public void Switch(int number)
    {
        if(currentHUD != null) Destroy(currentHUD);

        if(number==0) currentHUD = Instantiate(HUD[0], HUDParent);
        else if(number==1) currentHUD = Instantiate(HUD[1], HUDParent);
        else if(number==2) currentHUD = Instantiate(HUD[2], HUDParent);

    }

    private void OnDestroy()
    {
        GameEvent.instance.SwitchHUD -= Switch;
    }

}
