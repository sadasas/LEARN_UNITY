using UnityEngine;


public enum ItemType
{
    Health,
    Shoot,
}

 public struct ItemContainer
{
    public  ItemType itemtype;
   public Sprite imageSprite;

    public ItemContainer(ItemType _itemtype, Sprite _imageSprite)
    {
        this.itemtype = _itemtype;
        this.imageSprite = _imageSprite;
    }

}
public abstract class Item :ScriptableObject
{
  
    public abstract ItemContainer item { get; set; }
   public abstract void Function();

}
