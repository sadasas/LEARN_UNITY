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

    [SerializeField] private DataShop dataShop;

    public DataPlayer dataPlayer;
    [SerializeField] private CreateItem itemimage;

    public List<Item> inventoryPlayer;

    private void Start()
    {
        UpdateData();
    }

    private void Awake()
    {
        inputData = new InputData(namePlayer);
        outputData = new OutputData(HUD, namePlayerDisplay, expPlayerDisplay, tierDisplay, coinPlayerDisplay);
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
        ResetInventoryDisplay();
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
        inputData.addInventory(item);
        ResetInventoryDisplay();
    }

    private void PointSpawnItem()
    {
        GameObject spawnPoint = Instantiate(pointSpawnPrefab, inventoryPoint.position, inventoryPoint.rotation, inventoryPoint);
        pointSpawnItem = spawnPoint;
    }

    private void ResetInventoryDisplay()
    {
        int countChild = inventoryPoint.childCount;

        if (countChild > 0)
        {
            for (int i = 0; i < countChild; i++)
            {
                GameObject item = inventoryPoint.GetChild(i).gameObject;
                Destroy(item);
            }
        }

        LoadDataPlayer();
        PointSpawnItem();
        DisplayInventory();
    }

    private void DisplayInventory()
    {
        //convert

        if (inventoryPlayer != null)
        {
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
                            _itemSpawn.image = itemimage._listImage[inventoryPlayer[i].image];
                            _itemSpawn.detail = inventoryPlayer[i].detail;
                            _itemSpawn.type = inventoryPlayer[i].type.ToString();
                            _itemSpawn.owner = inventoryPlayer[i].owner;
                        }
                        else if (inventoryPlayer[i].type == TypeItem.EPIC)
                        {
                            GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                            _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                            _itemSpawn.name = inventoryPlayer[i].name;
                            _itemSpawn.cost = inventoryPlayer[i].cost;
                            _itemSpawn.image = itemimage._listImage[inventoryPlayer[i].image];
                            _itemSpawn.detail = inventoryPlayer[i].detail;
                            _itemSpawn.type = inventoryPlayer[i].type.ToString();
                            _itemSpawn.owner = inventoryPlayer[i].owner;
                        }
                        else
                        {
                            GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                            _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                            _itemSpawn.name = inventoryPlayer[i].name;
                            _itemSpawn.cost = inventoryPlayer[i].cost;
                            _itemSpawn.image = itemimage._listImage[inventoryPlayer[i].image];
                            _itemSpawn.detail = inventoryPlayer[i].detail;
                            _itemSpawn.type = inventoryPlayer[i].type.ToString();
                            _itemSpawn.owner = inventoryPlayer[i].owner;
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
                    _itemSpawn.image = itemimage._listImage[inventoryPlayer[i].image];
                    _itemSpawn.detail = inventoryPlayer[i].detail;
                    _itemSpawn.type = inventoryPlayer[i].type.ToString();
                    _itemSpawn.owner = inventoryPlayer[i].owner;
                }
                else if (inventoryPlayer[i].type == TypeItem.EPIC)
                {
                    GameObject itemSpawn = Instantiate(itemPrefab[1], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                    _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                    _itemSpawn.name = inventoryPlayer[i].name;
                    _itemSpawn.cost = inventoryPlayer[i].cost;
                    _itemSpawn.image = itemimage._listImage[inventoryPlayer[i].image];
                    _itemSpawn.detail = inventoryPlayer[i].detail;
                    _itemSpawn.type = inventoryPlayer[i].type.ToString();
                    _itemSpawn.owner = inventoryPlayer[i].owner;
                }
                else
                {
                    GameObject itemSpawn = Instantiate(itemPrefab[2], pointSpawnItem.transform.position, pointSpawnItem.transform.rotation, pointSpawnItem.transform);
                    _Item _itemSpawn = itemSpawn.GetComponent<_Item>();

                    _itemSpawn.name = inventoryPlayer[i].name;
                    _itemSpawn.cost = inventoryPlayer[i].cost;
                    _itemSpawn.image = itemimage._listImage[inventoryPlayer[i].image];
                    _itemSpawn.detail = inventoryPlayer[i].detail;
                    _itemSpawn.type = inventoryPlayer[i].type.ToString();
                    _itemSpawn.owner = inventoryPlayer[i].owner;
                }
            }
        }
    }
}