using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DatabaseGM: Database
{
   public void AddWeaponDatabase(WeaponDatabase weapon)
    {
        allWeapon.Add(weapon);
    }
   public void GetWeaponDatabase(List<WeaponDatabase> weapon)
    {
        foreach(WeaponDatabase wp in allWeapon)
        {
            weapon.Add(wp);
        }
    }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] List<WeaponDatabase> weaponInDatabase;
    [SerializeField] List<WeaponDatabase> _weaponInDatabase;
   
    _DatabaseGM database = new _DatabaseGM();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        foreach(WeaponDatabase weapon in weaponInDatabase)
        {
            database.AddWeaponDatabase(weapon); 
        }
    }

    private void Start()
    {
        database.GetWeaponDatabase(_weaponInDatabase);

    }






}
