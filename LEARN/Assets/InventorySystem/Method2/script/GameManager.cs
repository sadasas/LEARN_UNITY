using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InGameEquipment
{
    public string name = "Equipment";
    public GameObject prefab;
    public GameObject inventoryItem;
    public GameObject worldItem;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public InventorySlot2[] inventorySlots;

    public InGameEquipment[] equipment;

    private void Awake()
    {
        instance = this;
    }

    public void PickupItem(int itemID)
    {
        bool foundSlot = false;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (!inventorySlots[i].isFull)
            {
                GameObject GO = Instantiate(equipment[itemID].inventoryItem, inventorySlots[i].gameObject.transform);
                inventorySlots[i].currentItem = GO.GetComponent<InventoryItem2>();
                inventorySlots[i].isFull = true;
                foundSlot = true;
                break;
            }
        }
    }
}