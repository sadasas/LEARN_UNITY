
using UnityEngine;


[CreateAssetMenu(fileName ="item health name",menuName ="Item/Health")]
public class ItemHealthScriptableObject :  Item
{
   

    [SerializeField]  int Health;
    [SerializeField] Sprite imageSprite;
    [SerializeField] string nameItem,description;
    string empty;


    public override ItemContainer item { get ; set; }

    private void OnEnable()
    {
        item = new ItemContainer(ItemType.Health, imageSprite, nameItem, description,empty,empty);
    }
 
    public override void Function()
    {
        throw new System.NotImplementedException();
    }
}
