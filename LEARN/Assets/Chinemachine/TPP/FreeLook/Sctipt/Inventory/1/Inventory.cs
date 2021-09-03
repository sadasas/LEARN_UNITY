
using UnityEngine;
using System;



public class Inventory : MonoBehaviour
{
    //static
    public static Inventory instance;
    public static GameObject weaponEquiped;

    //inventory slot
    public ItemContainer itemContainer;
    [SerializeField] GameObject inventorySlotPrefab;

    //transform
    [SerializeField] Transform inventorySlotParent;
    [SerializeField] Transform inventorySlotEquipmentParent;
    [SerializeField] Transform[] _inventorySlot;


 


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AddInventorySlot(21);
    }
  

    void AddInventorySlot(int length)
    {
        //add inventory slot place anda inventory slot 
        itemContainer = new ItemContainer(length);
        _inventorySlot = new Transform[length];
        for (int i = 0; i < length-1; i++)
        {
          GameObject a= Instantiate(inventorySlotPrefab, inventorySlotParent);
            _inventorySlot[i] = a.transform;
          
        }

        //add inventory slot equipment
        GameObject inventorySlotEquipment = Instantiate(inventorySlotPrefab, inventorySlotEquipmentParent);
        inventorySlotEquipment.GetComponent<InventorySlot>().isWeaponSlot = true;
        
    }
    public void AddItemInventory(int ID)
    {
        // add item sprite to inventory slot place by index of place and index of array itemslot
        GameObject itemSprite = Instantiate(itemContainer._itemSlot[ID].item.itemSprite,_inventorySlot[ID]);
        itemSprite.transform.SetAsFirstSibling();
        itemSprite.GetComponent<ItemSlotUI>().ID = ID;
        _inventorySlot[ID].GetComponent<InventorySlot>().currentItem = itemSprite.GetComponent<ItemSlotUI>();
        _inventorySlot[ID].GetComponent<InventorySlot>().isFull = true;
    }

    public void AddItemHand(int ID)
    {
        //add item to hand 
        GameObject weapon = Instantiate(itemContainer._itemSlot[ID].item.itemHand, transform.GetChild(0).GetChild(3).GetChild(0));
        weaponEquiped = weapon;
        RigLayerManager.instance.StartLookWeapon();
    }

    public void AddItemWorld(int ID)
    {
        //add item to world
        Vector3 targetPos = transform.position ;
        RaycastHit hit;
        for (int i = 0; i <Mathf.Infinity; i++)
        {
            if (Physics.SphereCast(targetPos,1f, transform.forward,out hit,2f))
            {
                if(hit.transform.CompareTag("Object"))
                {
                    targetPos += transform.right * 2 ;

                }
             
            }
            else
            {
                Instantiate(itemContainer._itemSlot[ID].item.itemWorld,targetPos + transform.forward*2 + transform.up*0.5f, transform.rotation);
                Array.Clear(itemContainer._itemSlot, ID, 1);
                return;
            }
        }
       
    }
  




}
