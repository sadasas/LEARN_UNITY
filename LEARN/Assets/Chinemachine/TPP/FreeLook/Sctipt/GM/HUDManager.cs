using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] GameObject HUDInventory;
    private void Start()
    {
        GameEvents.instance.inventoryPressed += HUDInventorySetting;
    }

    void HUDInventorySetting()
    {
        if (HUDInventory.activeSelf) HUDInventory.SetActive(false);
        else HUDInventory.SetActive(true);
    }
}
