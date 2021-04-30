using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem2 : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Being drop");
        InventoryItem2 currentItem = eventData.pointerDrag.GetComponent<InventoryItem2>();
        InventorySlot2 currentSlot = currentItem.originSlot.GetComponent<InventorySlot2>();
        currentItem.canvasGroup.blocksRaycasts = true;
        currentSlot.isFull = false;
        currentSlot.currentItem = null;
        GameManager.instance.DropItem(currentItem);
    }
}