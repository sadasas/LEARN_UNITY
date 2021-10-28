
using UnityEngine;


[CreateAssetMenu(fileName ="item health name",menuName ="Item/Health")]
public class ItemHealthScriptableObject :  Item
{
   

    [SerializeField]  int Health;
    [SerializeField] Sprite imageSprite;


    public override ItemContainer item { get ; set; }

    private void OnEnable()
    {
        item = new ItemContainer(ItemType.Health, imageSprite);
    }
 
    public override void Function()
    {
        throw new System.NotImplementedException();
    }
}
