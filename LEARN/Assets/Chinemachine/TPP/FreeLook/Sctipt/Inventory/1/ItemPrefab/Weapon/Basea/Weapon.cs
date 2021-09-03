using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapon" ,order =1)]
public class Weapon : ScriptableObject
{
    [Multiline(2)]
    public string nameWeapon;
    [Multiline(5)]
    [SerializeField] string descriptionWeapon;

    [Space(10)]
    public int ID;
    public int damage;
    public float speed;
    public int maxAmmo;
    public AmmoType typeAmmo;


    [Range(0,1)]
    public float fireRate;
    public GameObject bulletDecal;
    public GameObject bulletPrefab;
}
