using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
public class WeaponPickup : MonoBehaviour
{
    WeaponManager weaponManager;
    private void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
    }


    private void OnTriggerStay(Collider other)
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        if (other.CompareTag("Player"))
        {
            InventoryPlayer.instance.AddNewWeapon(weaponManager);
            bc.enabled = false;

        }
    }
}
