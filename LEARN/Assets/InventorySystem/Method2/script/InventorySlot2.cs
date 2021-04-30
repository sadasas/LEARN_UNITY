using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot2 : MonoBehaviour, IDropHandler
{
    public InventoryItem2 currentItem;
    public bool isFull = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventoryItem2 newItem = eventData.pointerDrag.GetComponent<InventoryItem2>();
            InventorySlot2 OriginalSlot = newItem.originSlot.GetComponent<InventorySlot2>();

            //set previous slot item parent to null because item moved to this slot
            OriginalSlot.isFull = false;
            OriginalSlot.currentItem = null;

            //set this slot full
            isFull = true;
            currentItem = newItem;

            //set parent and tranform item  to this
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            currentItem.originSlot = this.transform;
        }
    }
}