using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    private SLData currentPlayer;
    private DataShop currentShop;
    [SerializeField] private Text nameItem;

    private DataPlayer dataPlayer;
    private List<Item> itemList;

    private void Awake()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<SLData>();
        currentShop = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<DataShop>();
    }

    private void Update()
    {
        UpdateAllData();
    }

    private void UpdateAllData()
    {
        dataPlayer = currentPlayer.dataPlayer;
        itemList = currentShop.itemInShop;
    }

    public void BuyItem()
    {
        foreach (var item in itemList)
        {
            if (nameItem.text == item.name)
            {
                if (dataPlayer.coin >= item.cost)
                {
                    currentPlayer.Buy(item.cost, item);
                }
                else
                {
                    Debug.Log("BUY ITEM : Not enaugh money");
                }
            }
            else
            {
                Debug.Log("BUY ITEM : Item not found in database");
            }
        }
    }
}