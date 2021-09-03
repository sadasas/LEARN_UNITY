
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
public struct itemSlot
{
    public Item item;
    public int quantity;
    public ItemType itemType;
    public int ID;
}

[CreateAssetMenu(menuName ="ItemSlot",fileName ="New Item")]
public class ItemSlot : ScriptableObject
{
  public itemSlot _itemSlot;
}
