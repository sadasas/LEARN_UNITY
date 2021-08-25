using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _DatabaseIP:Database
{
    public void GetWeaponDatabase(List<WeaponDatabase> weaponlist)
    {
        foreach(WeaponDatabase weapon in allWeapon)
        {
            weaponlist.Add(weapon);
        }
    }
}


public class InventoryPlayer : MonoBehaviour
{
    public static InventoryPlayer instance;
    _DatabaseIP database = new _DatabaseIP();


    [HideInInspector]
    public List<WeaponDatabase> weaponList = new List<WeaponDatabase>();

    [SerializeField] Dictionary<AmmoType, int> ammoStock = new Dictionary<AmmoType, int>();
    [SerializeField] InventorySlot[] inventorySlots ;

    public static GameObject weaponEquip { get; private set; }

    private void Awake()
    {
        weaponEquip = null;
        instance = this;
    }

    private void Start()
    {
        database.GetWeaponDatabase(weaponList);
    }

    public void AddWeaponInventory(int ID)
    {
     
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(!inventorySlots[i].isFull)
            {
                GameObject weapon = Instantiate(weaponList[ID].weaponSprite, inventorySlots[i].transform.position, Quaternion.identity, inventorySlots[i].transform);
                weapon.GetComponent<WeaponInventory>().ID = ID;
                inventorySlots[i].isFull = true;
                inventorySlots[i].currentItem = weapon.GetComponent<WeaponInventory>();
                break;
            }
        }
      
    }

    public void AddWeaponWorld(int ID)
    {
        GameObject dropItem = Instantiate(weaponList[ID].weaponWorldItem, transform.position + transform.forward * 2 + transform.up * 0.5f, weaponList[ID].weaponWorldItem.transform.rotation);
      
    }

    public void AddWWeaponHand(int ID)
    {
        GameObject dropItem = Instantiate(weaponList[ID].weaponPrefab, transform.GetChild(0).GetChild(3).GetChild(0).position, transform.GetChild(0).GetChild(3).GetChild(0).rotation);
        dropItem.transform.SetParent(transform.GetChild(0).GetChild(3).GetChild(0));


        RigLayerManager.instance.StartLookWeapon();
        weaponEquip = dropItem;
        dropItem.GetComponent<WeaponManager>().equiped = true;
    }

    public AmmoManager AddAmmo(AmmoManager ammo)
    {

        if (ammoStock.ContainsKey(ammo.contentsAmmo.ammoType))
        {
            ammoStock[ammo.contentsAmmo.ammoType] += ammo.contentsAmmo.Contents;
        }
        else
        {
            ammoStock.Add(ammo.contentsAmmo.ammoType, ammo.contentsAmmo.Contents);
        }

        return ammo;
    }

    public void FillAmmo(int ammoMax, AmmoType typeAmmo)
    {
        foreach (var ammo in ammoStock)
        {
            if (ammoStock.ContainsKey(typeAmmo))
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
