using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("New Food Item"), menuName = ("InventoryItem/Item/Food"))]
public class FoodItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Food;
    }
}