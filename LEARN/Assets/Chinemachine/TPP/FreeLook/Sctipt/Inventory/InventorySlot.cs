
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class InventorySlot : DropHandler
{
    public ItemSlotUI currentItem { get; set; }
    public bool isFull { get; set; }
    public bool isWeaponSlot { get; set; }



    [SerializeField] GameObject quantityUI;

   
    public override void OnDrop(PointerEventData eventData)
    {
      
        base.OnDrop(eventData);
        if(!isFull)
        {
            if (  !isWeaponSlot)
            {
                //set last inventory slot place to null
                originalSlot.isFull = false;
                originalSlot.currentItem = null;

                //set current inventory slot place to add drop item
                isFull = true;
                currentItem = newItem;
                //set transform and parent of item drop to this inventory slot item
                eventData.pointerDrag.transform.SetParent(this.transform);
                newItem.originalPos = this.transform;

                // change array item slot to match with index inventory slot place
                Array.Copy(Inventory.instance.itemContainer._itemSlot, currentItem.ID, Inventory.instance.itemContainer._itemSlot, transform.GetSiblingIndex(), 1);
                Inventory.instance.itemContainer._itemSlot[transform.GetSiblingIndex()].ID = transform.GetSiblingIndex();
                if (transform.GetSiblingIndex() != currentItem.ID) Array.Clear(Inventory.instance.itemContainer._itemSlot, currentItem.ID, 1);
                //set drop item id to match with this index inventory slot place because id is important to call array itemslot 
                currentItem.ID = transform.GetSiblingIndex();

                if (originalSlot.isWeaponSlot) Destroy(Inventory.weaponEquiped);

            }

            else
            { 
                //set last inventory slot place to null
                originalSlot.isFull = false;
                originalSlot.currentItem = null;

                //set current inventory slot place to add drop item
                isFull = true;
                currentItem = newItem;
                //set transform and parent of item drop to this inventory slot item
                eventData.pointerDrag.transform.SetParent(this.transform);
                newItem.originalPos = this.transform;
                //add weapon to hand by callback inventory script
               

                // change array item slot to match with index inventory slot place
                Array.Copy(Inventory.instance.itemContainer._itemSlot, currentItem.ID, Inventory.instance.itemContainer._itemSlot, 20, 1);
                if (20 == currentItem.ID) return;
                Inventory.instance.AddItemHand(newItem.ID);
                Array.Clear(Inventory.instance.itemContainer._itemSlot, currentItem.ID, 1);
                //set drop item id to match with this index inventory slot place because id is important to call array itemslot 
                currentItem.ID = 20;
                Inventory.instance.itemContainer._itemSlot[20].ID = 20;

            }
          
        }
     

        else if (isFull)
        {
           if(!isWeaponSlot)
            {   
                //transfer item in this place(inventory slot place) to item drop place 
                originalSlot.isFull = true;
                currentItem.gameObject.transform.SetParent(originalSlot.transform);
                currentItem.originalPos = originalSlot.transform;
                originalSlot.currentItem = currentItem;
                currentItem.transform.localPosition = Vector3.zero;

                //transfer drop item to this place(inventory slot place)
                newItem.transform.SetParent(this.transform);
                newItem.originalPos = this.transform;
                newItem.transform.localPosition = Vector3.zero;
                currentItem = newItem;

                //store itemslot in this place before changed
                ItemSlot a = Inventory.instance.itemContainer._itemSlot[transform.GetSiblingIndex()];
                //replace itemslot in this place to new drop itemslot
                Array.Copy(Inventory.instance.itemContainer._itemSlot, currentItem.ID, Inventory.instance.itemContainer._itemSlot, transform.GetSiblingIndex(), 1);
                Inventory.instance.itemContainer._itemSlot[transform.GetSiblingIndex()].ID = transform.GetSiblingIndex();
                //replace itemslot in drop item place to this item slot in store
                Inventory.instance.itemContainer._itemSlot.SetValue(a, currentItem.ID);
                Inventory.instance.itemContainer._itemSlot[currentItem.ID].ID = originalSlot.transform.GetSiblingIndex();
                //set index item slot in this to match with this place
                currentItem.ID = transform.GetSiblingIndex();
                //set index item slot in drop item to match with this place
                originalSlot.currentItem.ID = originalSlot.transform.GetSiblingIndex();
            }
           else
            {
                originalSlot.isFull = true;
                currentItem.gameObject.transform.SetParent(originalSlot.transform);
                currentItem.originalPos = originalSlot.transform;
                originalSlot.currentItem = currentItem;
                currentItem.transform.localPosition = Vector3.zero;

                newItem.transform.SetParent(this.transform);
                newItem.originalPos = this.transform;
                newItem.transform.localPosition = Vector3.zero;
                currentItem = newItem;

                //replace weapon equiped to new weapon drop
                Destroy(Inventory.weaponEquiped);
                Inventory.instance.AddItemHand(newItem.ID);

                //store itemslot in this place before changed
                ItemSlot a = Inventory.instance.itemContainer._itemSlot[20];
                //replace itemslot in this place to new drop itemslot
                Array.Copy(Inventory.instance.itemContainer._itemSlot, currentItem.ID, Inventory.instance.itemContainer._itemSlot, 20, 1);
                //replace itemslot in drop item place to this item slot in store
                Inventory.instance.itemContainer._itemSlot.SetValue(a, currentItem.ID);
                //set index item slot in this to match with this place
                currentItem.ID = 20;
                Inventory.instance.itemContainer._itemSlot[20].ID = 20;
                //set index item slot in drop item to match with this place
                originalSlot.currentItem.ID = originalSlot.transform.GetSiblingIndex();

            }

          
              


        }

       

    }

    private void Update()
    {
        if (!isWeaponSlot)
        {
            //set UI quantity
            quantityUI.SetActive(isFull);
            if (quantityUI.activeSelf)
            {
                quantityUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Inventory.instance.itemContainer._itemSlot[currentItem.ID].quantity.ToString();
                quantityUI.transform.SetAsLastSibling();
            }
        }
        else
        {
            //inactive if weapon slot
            quantityUI.SetActive(false);

        }
    }
}
