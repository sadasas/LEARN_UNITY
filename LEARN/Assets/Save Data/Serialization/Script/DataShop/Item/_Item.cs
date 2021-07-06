using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class _Item : MonoBehaviour
{
    //display

    [SerializeField] private Transform parent;
    [SerializeField] private Text[] nameItem;
    [SerializeField] private Text costItem;
    [SerializeField] private Text typeItem;
    [SerializeField] private Image imageItemShop;
    [SerializeField] private GameObject[] HUDDetail;

    //value

    public String type;
    public String name;
    public String detail;
    public int cost;
    public Sprite image;
    public Owner owner;

    private void Awake()
    {
        parent = transform.parent.parent.parent.parent;
    }

    private void Start()
    {
        nameItem[0].text = name;
        costItem.text = cost.ToString();
        typeItem.text = type;
        imageItemShop.sprite = image;
    }

    public void ClickDetail()
    {
        if (owner == Owner.SHOP)
        {
            GameObject spawnDetail = Instantiate(HUDDetail[0], parent.position, Quaternion.identity, parent);
            Transform namat = spawnDetail.transform.GetChild(0).GetChild(0).transform;
            Transform detailt = spawnDetail.transform.GetChild(0).GetChild(1).transform;
            namat.GetComponent<Text>().text = name;
            detailt.GetComponent<Text>().text = detail;
        }
        else
        {
            GameObject spawnDetail = Instantiate(HUDDetail[1], parent.position, Quaternion.identity, parent);
            Transform namat = spawnDetail.transform.GetChild(0).GetChild(0).transform;
            Transform detailt = spawnDetail.transform.GetChild(0).GetChild(1).transform;
            namat.GetComponent<Text>().text = name;
            detailt.GetComponent<Text>().text = detail;
        }
    }
}