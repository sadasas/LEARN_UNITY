using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLData : MonoBehaviour
{
    private InputData inputData;
    private OutputData outputData;

    [SerializeField] private Transform inventoryPoint;

    private GameObject pointSpawnItem;
    [SerializeField] private GameObject pointSpawnPrefab;

    //Input
    [SerializeField] private Text namePlayer;

    [SerializeField] private GameObject[] itemPrefab;

    //Output
    [SerializeField] private Text namePlayerDisplay, expPlayerDisplay, coinPlayerDisplay;

    [SerializeField] private GameObject[] tierDisplay, HUD;

    public DataPlayer dataPlayer;

    public List<Item> inventoryPlayer;

    private void Start()
    {
        UpdateData();
    }

    private void Awake()
    {
        inputData = new InputData(namePlayer);
        outputData = new OutputData(HUD, namePlayerDisplay, expPlayerDisplay, tierDisplay, coinPlayerDisplay);
        PointSpawnItem();
    }

    private void Update()
    {
    }

    public void SaveDataPlayer()
    {
        inputData.Save();
    }

    public void LoadDataPlayer()
    {
        outputData.Load();
        dataPlayer = outputData._dataPlayer;
        inventoryPlayer = inputData._inventory.itemPlayer;
    }

    public void ReplacedButton()
    {
        inputData.Reset();
        UpdateData();
    }

    public void UpdateData()
    {
        outputData.Update();
        dataPlayer = outputData._dataPlayer;
        inventoryPlayer = inputData._inventory.itemPlayer;
        // Debug.Log(inventoryPlayer.Count);
        // DisplayInventory();
    }

    public void AddXPPlayer()
    {
        inputData.AddXP();
        LoadDataPlayer();
    }

    public void AddCoinlayer()
    {
        inputData.AddCoin();
        LoadDataPlayer();
    }

    public void Buy(int itemCost, Item item)
    {
        inputData.LostCoin(itemCost);
        LoadDataPlayer();
        inputData.addInventory(item);
        DisplayInventory();
    }

    private void PointSpawnItem()
    {
        if (inventoryPoint.transform.childCount == 0 || pointSpawnItem.transform.childCount >= 4)
        {
            GameObject spawnPoint = Instantiate(pointSpawnPrefab, inventoryPoint.position, inventoryPoint.rotation, inventoryPoint);
            pointSpawnItem = spawnPoint;
        }
    }

    private void DisplayInventory()
    {
        //convert

        float iii = inventoryPlayer.Count / 4.0f;
        int convert = (int)Mathf.Floor(iii);
        float sisa = (iii - convert) / 0.25f;
        int ff = 4;

        if (convert >= 1)
        {
            for (int a = 0; a < convert; a++)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (inventoryPlayer[i].type == TypeItem.COMMON)
                    {
                        GameObject itemSpawn = Instantiate(itemPrefab[0], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                        _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                        _itemSpawn.name = inventoryPlayer[i].name;
                        _itemSpawn.cost = inventoryPlayer[i].cost;
                        _itemSpawn.image = inventoryPlayer[i].image;
                        _itemSpawn.detail = inventoryPlayer[i].detail;
                    }
                    else if (inventoryPlayer[i].type == TypeItem.EPIC)
                    {
                        GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                        _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                        _itemSpawn.name = inventoryPlayer[i].name;
                        _itemSpawn.cost = inventoryPlayer[i].cost;
                        _itemSpawn.image = inventoryPlayer[i].image;
                        _itemSpawn.detail = inventoryPlayer[i].detail;
                    }
                    else
                    {
                        GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                        _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                        _itemSpawn.name = inventoryPlayer[i].name;
                        _itemSpawn.cost = inventoryPlayer[i].cost;
                        _itemSpawn.image = inventoryPlayer[i].image;
                        _itemSpawn.detail = inventoryPlayer[i].detail;
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
            if (inventoryPlayer[i].type == TypeItem.COMMON)
            {
                GameObject itemSpawn = Instantiate(itemPrefab[0], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = inventoryPlayer[i].name;
                _itemSpawn.cost = inventoryPlayer[i].cost;
                _itemSpawn.image = inventoryPlayer[i].image;
                _itemSpawn.detail = inventoryPlayer[i].detail;
            }
            else if (inventoryPlayer[i].type == TypeItem.EPIC)
            {
                GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = inventoryPlayer[i].name;
                _itemSpawn.cost = inventoryPlayer[i].cost;
                _itemSpawn.image = inventoryPlayer[i].image;
                _itemSpawn.detail = inventoryPlayer[i].detail;
            }
            else
            {
                GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                _itemSpawn.name = inventoryPlayer[i].name;
                _itemSpawn.cost = inventoryPlayer[i].cost;
                _itemSpawn.image = inventoryPlayer[i].image;
                _itemSpawn.detail = inventoryPlayer[i].detail;
            }
        }
    }
}