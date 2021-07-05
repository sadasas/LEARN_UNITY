using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataShop : MonoBehaviour
{
    public CreateItem createItem;

    public List<Item> itemInShop = new List<Item>();

    [SerializeField] private Transform shopPoint;

    [SerializeField] private GameObject pointSpawnPrefab;

    private GameObject pointSpawnItem;

    [SerializeField] private Sprite pedangEskalibur;
    [SerializeField] private Sprite celuritSakti;
    [SerializeField] private Sprite sevenblestLur;
    [SerializeField] private Sprite spearMagic;

    [SerializeField] private String detailPedangEskalibur;
    [SerializeField] private String detailceluritSakti;
    [SerializeField] private String detailsevenblestLur;
    [SerializeField] private String detailspearMagic;

    [SerializeField] private List<GameObject> itemPrefab = new List<GameObject>();

    private void Awake()
    {
        createItem = new CreateItem(pedangEskalibur, celuritSakti, sevenblestLur, spearMagic, detailPedangEskalibur, detailceluritSakti, detailsevenblestLur, detailspearMagic);
        createItem.CeckItemDatabase();
        createItem.DefaultItem();
        itemInShop = createItem._itemAvailable;
        PointSpawnItem();
    }

    private void Start()
    {
        DisplayItem();
    }

    private void Update()
    {
    }

    public void addItem()
    {
        createItem.AddItem();
    }

    private void PointSpawnItem()
    {
        if (shopPoint.transform.childCount == 0 || pointSpawnItem.transform.childCount >= 4)
        {
            GameObject spawnPoint = Instantiate(pointSpawnPrefab, shopPoint.position, shopPoint.rotation, shopPoint);
            pointSpawnItem = spawnPoint;
        }
    }

    private void DisplayItem()
    {
        //convert

        float iii = itemInShop.Count / 4.0f;
        int convert = (int)Mathf.Floor(iii);
        float sisa = (iii - convert) / 0.25f;
        int ff = 4;

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
                        _itemSpawn.image = itemInShop[i].image;
                        _itemSpawn.detail = itemInShop[i].detail;
                    }
                    else if (itemInShop[i].type == TypeItem.EPIC)
                    {
                        GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                        _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                        _itemSpawn.name = itemInShop[i].name;
                        _itemSpawn.cost = itemInShop[i].cost;
                        _itemSpawn.image = itemInShop[i].image;
                        _itemSpawn.detail = itemInShop[i].detail;
                    }
                    else
                    {
                        GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                        _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                        _itemSpawn.name = itemInShop[i].name;
                        _itemSpawn.cost = itemInShop[i].cost;
                        _itemSpawn.image = itemInShop[i].image;
                        _itemSpawn.detail = itemInShop[i].detail;
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
                _itemSpawn.image = itemInShop[i].image;
                _itemSpawn.detail = itemInShop[i].detail;
            }
            else if (itemInShop[i].type == TypeItem.EPIC)
            {
                GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = itemInShop[i].name;
                _itemSpawn.cost = itemInShop[i].cost;
                _itemSpawn.image = itemInShop[i].image;
                _itemSpawn.detail = itemInShop[i].detail;
            }
            else
            {
                GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = itemInShop[i].name;
                _itemSpawn.cost = itemInShop[i].cost;
                _itemSpawn.image = itemInShop[i].image;
                _itemSpawn.detail = itemInShop[i].detail;
            }
        }
    }
}