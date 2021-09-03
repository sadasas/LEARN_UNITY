
using UnityEngine.EventSystems;

public class DropWorld : DropHandler
{
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        originalSlot.isFull = false;
        originalSlot.currentItem = null;
        Inventory.instance.AddItemWorld(newItem.ID);
        if (originalSlot.isWeaponSlot) Destroy(Inventory.weaponEquiped);
        Destroy(newItem.gameObject);


    }
}
