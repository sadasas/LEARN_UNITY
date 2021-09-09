using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItemContainer
{
    void AddItemSlot(ItemSlotScriptableObject itemSlot);
    void RemoveItemSlot(int ID);
}
