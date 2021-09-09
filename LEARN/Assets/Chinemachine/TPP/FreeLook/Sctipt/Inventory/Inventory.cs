
using UnityEngine;
using System;



public class Inventory : MonoBehaviour
{
    //static
    public static Inventory instance;
    public static GameObject weaponEquiped;

    //inventory slot
    public ItemContainer itemContainer { get => _itemContainer; }
    [SerializeField] ItemContainer _itemContainer;
    [SerializeField] GameObject inventorySlotPrefab;

    //transform
    [SerializeField] Transform inventorySlotParent;
    [SerializeField] Transform inventorySlotEquipmentParent;
    [SerializeField] Transform[] _inventorySlot;


    private void Awake() => instance = this;

    private void Start()
    {
        _itemContainer = new ItemContainer(0);
        AddInventorySlot(21);
        LoadData();
    }

    private void OnDestroy() => SaveData();



    void LoadData()
    {
        _itemContainer = SaveLoad.LoadData().itemContainer;

        if (_itemContainer == null)
        {
            AddItemContainer(21);
            Debug.Log("add");
            PlayerData pd = new PlayerData(_itemContainer);
            SaveLoad.SaveData(pd);
            return;
        }
        foreach (ItemSlot item in _itemContainer._itemSlot)
        {
            if (item.quantity > 0) AddItemInventory(item.ID);
        }

    }

    void SaveData()
    {
        PlayerData pd = new PlayerData(_itemContainer);
        SaveLoad.SaveData(pd);
    }



    void AddItemContainer(int length)
    {
        _itemContainer = new ItemContainer(length);
    }
    void AddInventorySlot(int length)
    {
        //add inventory slot place anda inventory slot 
      
        _inventorySlot = new Transform[length];
        for (int i = 0; i < length-1; i++)
        {
          GameObject a= Instantiate(inventorySlotPrefab, inventorySlotParent);
            _inventorySlot[i] = a.transform;
        }

        //add inventory slot equipment
        GameObject inventorySlotEquipment = Instantiate(inventorySlotPrefab, inventorySlotEquipmentParent);
        inventorySlotEquipment.GetComponent<InventorySlot>().isWeaponSlot = true;
        _inventorySlot[20] = inventorySlotEquipment.transform;
        
    }


    public void UpdateAmmo(int ID ,int ammo)
    {
       _itemContainer._itemSlot[ID].quantity = ammo;
    }

    public void AddItemInventory(int ID)
    {
        // add item sprite to inventory slot place by index of place and index of array itemslot
        GameObject itemSprite = Instantiate(itemContainer._itemSlot[ID].item.itemSprite,_inventorySlot[ID]);
        itemSprite.GetComponent<ItemSlotUI>().ID = ID;

        if (itemContainer._itemSlot[ID].itemType == ItemType.AMMO)
        {
            Debug.Log(" ammo");
           // itemSprite.GetComponent<IAmmo>().UpdateAmmo(ID);
        }

        _inventorySlot[ID].GetComponent<InventorySlot>().currentItem = itemSprite.GetComponent<ItemSlotUI>();
        _inventorySlot[ID].GetComponent<InventorySlot>().isFull = true;
        if (ID == 20) AddItemHand(ID);

       
    }

    public void AddItemHand(int ID)
    {
        //add item to hand 
        GameObject weapon = Instantiate(itemContainer._itemSlot[ID].item.itemHand, transform.GetChild(0).GetChild(3).GetChild(0));
        weaponEquiped = weapon;
        RigLayerManager.instance.FirstLookState();
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

    public void DestroyItemInventory(int ID)
    {
        itemContainer.RemoveItemSlot(ID);
        _inventorySlot[ID].GetComponent<InventorySlot>().currentItem = null;
        _inventorySlot[ID].GetComponent<InventorySlot>().isFull = false;
    }

}
