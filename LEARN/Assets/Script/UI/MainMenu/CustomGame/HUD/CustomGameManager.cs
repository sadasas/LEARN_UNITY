using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public abstract class CustomGameManager : MonoBehaviour
{
    protected static CustomGame gameSetup ;

    public ResourceHandler rh;



    public virtual void InvokeSwitchMenu(int number)
    {
        GameEvent.instance.SwitchHUD?.Invoke(number);
       
    }

    
    public virtual void SaveSetting()
    {
        Debug.Log(gameSetup.ai.unitEnemy);
        Debug.Log(gameSetup.player.typeUnit);

    }

    public virtual void PlayCustom()
    {
      
        GameEvent.instance.SaveSettingCustomGame?.Invoke(gameSetup);
    }
}
