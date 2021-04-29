using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Default,
    Equipment
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject Prefab;
    public ItemType type;

    [TextArea(15, 20)]
    public string description;
}