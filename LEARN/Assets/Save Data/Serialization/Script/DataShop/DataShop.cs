using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataShop : MonoBehaviour
{
    private CreateItem createItem;

    public List<Item> itemInShop = new List<Item>();

    [SerializeField] private Transform shopPoint;

    [SerializeField] private List<GameObject> itemPrefab = new List<GameObject>();

    private void Awake()
    {
        createItem = new CreateItem();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayItem();
        }

        itemInShop = createItem._itemAvailable;

        createItem.CeckItemDatabase();
    }

    public void addItem()
    {
        createItem.AddItem();
    }

    private void DisplayItem()
    {
        foreach (Item item in itemInShop)
        {
            if (item.type == TypeItem.COMMON)
            {
                GameObject itemSpawn = Instantiate(itemPrefab[0], shopPoint.position, shopPoint.rotation, shopPoint);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = item.name;
                _itemSpawn.cost = item.cost;
            }
            else if (item.type == TypeItem.EPIC)
            {
                GameObject itemSpawn = Instantiate(itemPrefab[1], shopPoint.position, shopPoint.rotation, shopPoint);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = item.name;
                _itemSpawn.cost = item.cost;
            }
            else
            {
                GameObject itemSpawn = Instantiate(itemPrefab[2], shopPoint.position, shopPoint.rotation, shopPoint);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = item.name;
                _itemSpawn.cost = item.cost;
            }
        }
    }
}