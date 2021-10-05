
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    //static
    public static GameEvents instance;
    public static event Action ShootPressed,ChargingPressed;

    private void Awake()=> instance = this;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) ChargingPressed?.Invoke();
       else if(Input.GetKeyUp(KeyCode.Mouse0)) ShootPressed?.Invoke();
    }

}
