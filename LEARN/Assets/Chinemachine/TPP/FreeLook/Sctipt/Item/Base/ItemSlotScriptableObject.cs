
using UnityEngine;
using System;



[Serializable]
 public struct Item
{
  public string name;
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

    public ItemType itemType;
    public int quantity { get; set; }
    public int ID { get; set; }



}

[CreateAssetMenu(menuName ="ItemSlot",fileName ="New Item")]
public class ItemSlotScriptableObject : ScriptableObject
{
  public ItemSlot itemSlot;

   
}
