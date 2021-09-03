using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public  struct ItemDatabase
{
    public string name;
    public GameObject itemPrefab;
    public GameObject itemWorldItem;
    public GameObject itemSprite;
}



public abstract class Database
{ 
    protected static List<ItemDatabase> allItem = new List<ItemDatabase>();
}
