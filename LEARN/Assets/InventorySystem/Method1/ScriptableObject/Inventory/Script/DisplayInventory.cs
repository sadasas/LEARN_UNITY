using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public int x_space;
    public int y_space;

    public int x_start;
    public int y_start;
    public int number_of_collumn;

    public InventoryObject inventory;

    public Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateaDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].Amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.Prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].Amount.ToString("n0");
                itemDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void CreateaDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].Amount.ToString("n0");
            itemDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_start + (x_space * (i % number_of_collumn)), y_start + (-y_space * (i / number_of_collumn)), 0);
    }
}