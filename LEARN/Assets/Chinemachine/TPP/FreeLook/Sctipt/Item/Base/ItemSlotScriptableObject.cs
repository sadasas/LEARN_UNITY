
using UnityEngine;
using System;



[Serializable]
 public struct Item
{
  public  GameObject itemHand;
  public  GameObject itemWorld;
  public  GameObject itemSprite;
}

[Serializable]
public enum ItemType
{
    WEAPON,
    AMMO
}

[Serializable]
public struct ItemSlot
{
    public Item item;
    public int quantity;
    public ItemType itemType;
    public int ID;
}

[CreateAssetMenu(menuName ="ItemSlot",fileName ="New Item")]
public class ItemSlotScriptableObject : ScriptableObject
{
  public ItemSlot itemSlot;
}
