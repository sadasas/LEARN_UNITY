
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag!=null)
        {
            WeaponInventory dropItem = eventData.pointerDrag.GetComponent<WeaponInventory>();
            InventorySlot lastSlot = dropItem.originalPos.GetComponent<InventorySlot>();

            lastSlot.isFull = false;
            lastSlot.currentItem = null;

            InventoryPlayer.instance.AddWeaponWorld(dropItem.ID);
            Destroy(eventData.pointerDrag);
        }
    }
}
