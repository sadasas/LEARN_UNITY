using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IDropHandler
{
    public WeaponInventory currentItem;
    public bool isFull = false;
    [SerializeField] bool isWeaponSlot;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            WeaponInventory newItem = eventData.pointerDrag.GetComponent<WeaponInventory>();
            InventorySlot originalSlot = newItem.originalPos.GetComponent<InventorySlot>();
            if (!isFull && !isWeaponSlot)
            {
                originalSlot.isFull = false;
                originalSlot.currentItem = null;

                isFull = true;
                currentItem = newItem;
                eventData.pointerDrag.transform.SetParent(this.transform);
                newItem.originalPos = this.transform;
            }

            if(!isFull&&isWeaponSlot)
            {
                originalSlot.isFull = false;
                originalSlot.currentItem = null;

                isFull = true;
                currentItem = newItem;
                eventData.pointerDrag.transform.SetParent(this.transform);
                newItem.originalPos = this.transform;

                InventoryPlayer.instance.AddWWeaponHand(newItem.ID);
            }
        }
      
    }
}
