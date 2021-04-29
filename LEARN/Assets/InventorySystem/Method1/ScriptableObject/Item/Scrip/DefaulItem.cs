using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = ("InventoryItem/Item/Default"))]
public class DefaulItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Default;
    }
}