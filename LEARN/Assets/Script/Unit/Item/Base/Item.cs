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
    public string name, description, abilty, skill;

    public ItemContainer(ItemType _itemtype, Sprite _imageSprite, string _Name, string _Description, string _Abilty, string _Skill)
    {
        this.itemtype = _itemtype;
        this.imageSprite = _imageSprite;
        this.name = _Name;
        this.description = _Description;
        this.abilty = _Abilty;
        this.skill = _Skill;
    }

}
public abstract class Item :ScriptableObject
{
  
    public abstract ItemContainer item { get; set; }
   public abstract void Function();

}
