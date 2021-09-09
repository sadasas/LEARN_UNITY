
using System;


[Serializable]
public class ItemContainer :  IItemContainer
{
   //contains
    public ItemSlot[] _itemSlot = new ItemSlot[0];

    public ItemContainer (int size) => _itemSlot = new ItemSlot[size];
    public void AddItemSlot(ItemSlotScriptableObject itemSlot)
    {
        for (int i = 0; i < _itemSlot.Length; i++)
        {
            if(_itemSlot[i].item.itemSprite==null)
            {
                 itemSlot.UpdateSlot();
                _itemSlot.SetValue(itemSlot.itemSlot, i);
                _itemSlot[i].ID = i;
                 Inventory.instance.AddItemInventory(i);

              

                
                return;
            }
        }
    }

    public void RemoveItemSlot(int _ID) => Array.Clear(_itemSlot, _ID, 1);

   

}   
