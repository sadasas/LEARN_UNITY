using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory :MonoBehaviour
{
    List<Item> _itemInventory;
  

    public List<Item> itemInventory { get => _itemInventory; }


   


    public Item AddItem(Item item)
    {
        if (_itemInventory == null) _itemInventory = new List<Item>();
        _itemInventory.Add(item);
        ShowItem(item);
        return item;
    }

    public abstract void ShowItem(Item item);
}
