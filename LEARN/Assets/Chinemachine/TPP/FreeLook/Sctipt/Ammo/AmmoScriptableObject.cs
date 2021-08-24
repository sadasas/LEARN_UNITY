using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Ammo", order = 1)]
public class AmmoScriptableObject : ScriptableObject
{
    public AmmoType ammoType;
    public int Contents;
}
