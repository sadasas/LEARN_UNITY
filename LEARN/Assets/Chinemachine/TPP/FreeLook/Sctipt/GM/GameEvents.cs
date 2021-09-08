using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    public event Action shootPressed, jumpPressed, reloadPressed, aimPressed,idle,inventoryPressed,resetAnim;
   

    private void Awake() => instance = this;

    private void Update()
    {
        bool _aimPressed = Input.GetKey(KeyCode.Mouse1);
        bool _shootPressed = Input.GetKey(KeyCode.Mouse0);
        bool _reloadPressed = Input.GetKey(KeyCode.R);
        bool _jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool _inventoryPressed = Input.GetKeyDown(KeyCode.Escape);

        if (_jumpPressed) jumpPressed?.Invoke();
        if (_inventoryPressed) inventoryPressed?.Invoke();
        if (Inventory.weaponEquiped)
        {
            if (_aimPressed) aimPressed?.Invoke();
            if (_shootPressed) shootPressed?.Invoke();
            if (_reloadPressed) reloadPressed?.Invoke();
            if (!_aimPressed && !_shootPressed && !_reloadPressed) idle?.Invoke();
        }
        else resetAnim?.Invoke();
    }

 
}
