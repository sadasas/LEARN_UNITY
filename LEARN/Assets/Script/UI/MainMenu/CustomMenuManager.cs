using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 MAKE ABSTRACT CLASS TO BE BASE OF ALL HUD MANAGER
 
 */
public class CustomMenuManager : MonoBehaviour
{
    [Header("Custom Game")]
    [SerializeField] Text numberEnemy;
    

    public void InvokeSwitchMenu(int number)
    {
        GameEvent.instance.SwitchHUD?.Invoke(number);
    }

   

    public void SaveSetting()
    {
        GameEvent.instance.SaveSettingCustomGame?.Invoke(Int32.Parse(numberEnemy.text),1);
    }

    
}
