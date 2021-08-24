using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    public static InventoryPlayer instance;



    [SerializeField] List<WeaponManager> weaponList = new List<WeaponManager>();

    [SerializeField] Dictionary<AmmoType, int> ammoStock = new Dictionary<AmmoType, int>();

    public static GameObject weaponEquip { get; private set; }

    private void Awake()
    {
        weaponEquip = null;
        instance = this;
    }

   public WeaponManager AddWeapon(WeaponManager weapon)
    {
        weaponList.Add(weapon);
        RigLayerManager.instance.StartLookWeapon();
        weaponEquip = weapon.gameObject;
        weapon.equiped = true;
        return weapon;
    }

   public AmmoManager AddAmmo(AmmoManager ammo)
    {

        if(ammoStock.ContainsKey(ammo.contentsAmmo.ammoType))
        {
            ammoStock[ammo.contentsAmmo.ammoType] += ammo.contentsAmmo.Contents;
        }
        else
        {
            ammoStock.Add(ammo.contentsAmmo.ammoType, ammo.contentsAmmo.Contents);
        }

        return ammo;
    }

    public void FillAmmo(int ammoMax,AmmoType typeAmmo)
    {
        foreach(var ammo in ammoStock)
        {
            if(ammoStock.ContainsKey(typeAmmo))
            {
                if (ammo.Value > ammoMax)
                {
                    weaponEquip.GetComponent<WeaponManager>().ammoAvailable += ammoMax;
                    ammoStock[typeAmmo] -= ammoMax;
                    return;
                }

                else
                {
                    weaponEquip.GetComponent<WeaponManager>().ammoAvailable += ammo.Value;
                    ammoStock.Remove(typeAmmo);
                    return;
                }
            }

        }

       
        
    }

   

}
