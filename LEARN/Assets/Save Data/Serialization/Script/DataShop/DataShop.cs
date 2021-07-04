using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataShop : MonoBehaviour
{
    private CreateItem createItem;

    public List<Item> itemInShop = new List<Item>();

    [SerializeField] private Transform shopPoint;

    [SerializeField] private GameObject pointSpawnPrefab;

    private GameObject pointSpawnItem;

    [SerializeField] private List<GameObject> itemPrefab = new List<GameObject>();

    private void Awake()
    {
        createItem = new CreateItem();
        createItem.CeckItemDatabase();
        createItem.DefaultItem();
        itemInShop = createItem._itemAvailable;
        PointSpawnItem();
    }

    private void Start()
    {
        DisplayItem();
    }

    private void PointSpawnItem()
    {
        if (shopPoint.transform.childCount == 0 || pointSpawnItem.transform.childCount >= 4)
        {
            GameObject spawnPoint = Instantiate(pointSpawnPrefab, shopPoint.position, shopPoint.rotation, shopPoint);
            pointSpawnItem = spawnPoint;
        }
    }

    private void Update()
    {
        Debug.Log(itemInShop.Count);

        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayItem();
        }
    }

    public void addItem()
    {
        createItem.AddItem();
    }

    private void DisplayItem()
    {
        {
            //convert

            float iii = itemInShop.Count / 4.0f;
            int convert = (int)Mathf.Floor(iii);
            float sisa = (iii - convert) / 0.25f;
            int ff = 4;
            Debug.Log(convert);

            if (convert >= 1)
            {
                for (int a = 0; a < convert; a++)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (itemInShop[i].type == TypeItem.COMMON)
                        {
                            GameObject itemSpawn = Instantiate(itemPrefab[0], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                            _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                            _itemSpawn.name = itemInShop[i].name;
                            _itemSpawn.cost = itemInShop[i].cost;
                        }
                        else if (itemInShop[i].type == TypeItem.EPIC)
                        {
                            GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                            _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                            _itemSpawn.name = itemInShop[i].name;
                            _itemSpawn.cost = itemInShop[i].cost;
                        }
                        else
                        {
                            GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                            _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                            _itemSpawn.name = itemInShop[i].name;
                            _itemSpawn.cost = itemInShop[i].cost;
                        }
                    }
                    PointSpawnItem();
                }
            }
            else
            {
                ff = 0;
            }

            for (int i = ff; i < sisa + ff; i++)
            {
                if (itemInShop[i].type == TypeItem.COMMON)
                {
                    GameObject itemSpawn = Instantiate(itemPrefab[0], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                    _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                    _itemSpawn.name = itemInShop[i].name;
                    _itemSpawn.cost = itemInShop[i].cost;
                }
                else if (itemInShop[i].type == TypeItem.EPIC)
                {
                    GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                    _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                    _itemSpawn.name = itemInShop[i].name;
                    _itemSpawn.cost = itemInShop[i].cost;
                }
                else
                {
                    GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                    _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                    _itemSpawn.name = itemInShop[i].name;
                    _itemSpawn.cost = itemInShop[i].cost;
                }
            }
        }
    }
}