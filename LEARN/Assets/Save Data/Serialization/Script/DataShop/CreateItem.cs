using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : DatabaseShop
{
    private List<Item> itemAvailable = new List<Item>();

    public List<Item> _itemAvailable { get { return itemAvailable; } }

    public void AddItem()
    {
        item = new Item("Pedang", TypeItem.RARE, 1000);
        allitem.allItemInSHOP.Add(item);
    }

    public void DefaultItem()
    {
        item = new Item("Pedang", TypeItem.RARE, 1000);
        allitem.allItemInSHOP.Add(item);
        item = new Item("tt", TypeItem.RARE, 1000);
        allitem.allItemInSHOP.Add(item);
        item = new Item("dd", TypeItem.RARE, 1000);
        allitem.allItemInSHOP.Add(item);
        /* item = new Item("dd", TypeItem.RARE, 1000);
         allitem.allItemInSHOP.Add(item);*/
    }

    public override DatabaseAdded CeckItemDatabase()
    {
        if (_isExist == base.CeckItemDatabase())
        {
            itemAvailable = _allItem.allItemInSHOP;
        }
        return base.CeckItemDatabase();
    }

    public override void Update()
    {
    }
}