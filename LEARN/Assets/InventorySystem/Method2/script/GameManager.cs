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
    public Transform player;
    public Transform handPlayer;

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

    public void DropItem(InventoryItem2 item)
    {
        Debug.Log("drop item");
        Instantiate(equipment[item.itemID].worldItem, player.position + new Vector3(0, 0, 2), Quaternion.identity);
        Destroy(item.gameObject);
    }

    public void SpawnWeapon()
    {
        Instantiate(equipment[0].worldItem, handPlayer.position, Quaternion.identity, handPlayer);
        equipment[0].worldItem.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void DestroyWeaopn()
    {
        Debug.Log("DESTROY");
        Destroy(handPlayer.GetChild(0).gameObject);
    }
}