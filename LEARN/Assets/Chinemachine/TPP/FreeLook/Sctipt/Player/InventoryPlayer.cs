using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{

    public static InventoryPlayer instance;
    [SerializeField] List<WeaponManager> weaponList = new List<WeaponManager>();

    [SerializeField] WeaponManager currentWeapon;
    [SerializeField] Transform weaponParent;
    [SerializeField] float trowhWeaponDistance;
    public GameObject weaponEquip;


    private void Awake()
    {
        instance = this;
    }
    public void AddNewWeapon(WeaponManager weapon)
    {
        weaponList.Add(weapon);
      
        EquipWeapon(weapon);

    }

    private void Update()
    {
        
    }

    void EquipWeapon(WeaponManager weapon)
    {
        if (weaponEquip != null)
        {
            UnequipWeapon();

        }
        currentWeapon = weapon;
        weaponEquip = currentWeapon.gameObject;
        weaponEquip.transform.position = weaponParent.position;
        weaponEquip.transform.rotation = weaponParent.rotation;
        weaponEquip.transform.SetParent(weaponParent);
        
    }

    void UnequipWeapon()
    {
        weaponList.Remove(currentWeapon);
        weaponEquip.transform.SetParent(null);
        weaponEquip.transform.position = transform.position + transform.forward * trowhWeaponDistance;
        BoxCollider bc = weaponEquip.GetComponent<BoxCollider>();
        bc.enabled = true;
    }

}   
