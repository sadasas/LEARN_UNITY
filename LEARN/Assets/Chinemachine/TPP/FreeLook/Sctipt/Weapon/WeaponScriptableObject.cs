using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    GUN,
    MELEE,
}
[CreateAssetMenu(menuName ="Weapon", order =1)]
public class WeaponScriptableObject : ScriptableObject
{

    public WeaponType weaponType;

    [TextArea(1,100)]
    public string nameWeapon;

    public int damage;

    public GameObject weaponPrefab;
        
   
  
}
