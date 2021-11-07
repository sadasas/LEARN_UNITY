using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 MAKE ABSTRACT CLASS TO BE BASE OF ALL HUD MANAGER
 
 */
public class MenuManager : MonoBehaviour
{

    [SerializeField] ResourceHandler rh;
    [SerializeField] Transform HUDParent;
   

    GameObject currentHUD;

    private void Start()
    {
        currentHUD = Instantiate(rh.allcustomGameHUDPrefab[0], this.transform);
        GameEvent.instance.SwitchHUD += Switch;
    }



    public void Switch(int number)
    {
        if(currentHUD != null) Destroy(currentHUD);

        if(number==0) currentHUD = Instantiate(rh.allcustomGameHUDPrefab[0], HUDParent);
        else if(number==1) currentHUD = Instantiate(rh.allcustomGameHUDPrefab[1], HUDParent);
        else if(number==2) currentHUD = Instantiate(rh.allcustomGameHUDPrefab[2], HUDParent);
        else if(number==3) currentHUD = Instantiate(rh.allcustomGameHUDPrefab[3], HUDParent);

    }

    private void OnDestroy()
    {
        GameEvent.instance.SwitchHUD -= Switch;
    }

}
