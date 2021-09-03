
using System;


[Serializable]
public class ItemContainer :  IItemContainer
{
   
    public itemSlot[] _itemSlot = new itemSlot[0];
    
    
    public ItemContainer (int size)
    {
        _itemSlot = new itemSlot[size];
      
    }
    public void AddItemSlot(ItemSlot itemSlot)
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            if(_itemSlot[i].item.itemSprite==null)
            {
                _itemSlot.SetValue(itemSlot._itemSlot, i);
                _itemSlot[i].ID = i;  

                 Inventory.instance.AddItemInventory(i);
                return;
            }
        }
    }

    public void RemoveItemSlot(ItemSlot itemSlot)
    {
       
    }
}
