using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public  struct WeaponDatabase
{
    public string name;
    public GameObject weaponPrefab;
    public GameObject weaponWorldItem;
    public GameObject weaponSprite;
}
public enum AmmoType
{
  GUN,
  SUBMACHINE,
  RIFFLE
}



public abstract class Database  
{

    protected static List<WeaponDatabase> allWeapon = new List<WeaponDatabase>();
  
}
