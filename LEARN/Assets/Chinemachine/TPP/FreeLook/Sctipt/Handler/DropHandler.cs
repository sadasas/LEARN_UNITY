
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropHandler : MonoBehaviour, IDropHandler
{
   protected ItemSlotUI newItem;
   protected InventorySlot originalSlot;
    
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
       
        newItem = eventData.pointerDrag.GetComponent<ItemSlotUI>();
        originalSlot = newItem.originalPos.GetComponent<InventorySlot>();
      
       
      
    }
}
