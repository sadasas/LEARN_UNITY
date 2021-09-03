using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager :MonoBehaviour,IAmmo
{
   [SerializeField] Ammo contentsAmmo;
    public int ammo { get => contentsAmmo.ammo; }
    public AmmoType ammoType { get => contentsAmmo.type; }

   
    private void OnEnable()
    {
        
    }
    public void UpdateAmmo(int ID)
    {
       Inventory.instance.itemContainer._itemSlot[ID].quantity = contentsAmmo.ammo;
    

    }
    public void AmmoAvailable(int ammoEquiped)
    {
       contentsAmmo.ammo -= ammoEquiped;
       
    }

    private void Update()
    {
        Debug.Log("Ammo"+ammo);
    }

}
