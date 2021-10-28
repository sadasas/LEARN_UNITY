using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 MAKE ABSTRACT CLASS TO BE BASE OF ALL HUD MANAGER
 
 */
public class MainMenuManager : MonoBehaviour
{
    public void InvokeSwitchMenu(int number)
    {
        GameEvent.instance.SwitchHUD?.Invoke(number);
    }

}
