using System;

using UnityEngine;


/*
 ANOYING SINGLETON
 */
public class GameEvent : MonoBehaviour
{
    public static GameEvent instance;

    public Func<int, CustomGame> playCustomGame;
    public Func<int,int, CustomGame> SaveSettingCustomGame;

    public Action<int> SwitchHUD;
    public Action playCustomBtn;

    private void OnEnable()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);
    }

    
}
