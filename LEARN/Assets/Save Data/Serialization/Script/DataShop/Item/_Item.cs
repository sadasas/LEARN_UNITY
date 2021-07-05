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
    [SerializeField] private Image imageItem;
    [SerializeField] private GameObject HUDDetail;

    //value

    public String type;
    public String name;
    public String detail;
    public int cost;
    public Sprite image;

    private void Awake()
    {
        parent = transform.parent.parent.parent.parent;
    }

    private void Start()
    {
        nameItem[0].text = name;

        costItem.text = cost.ToString();

        typeItem.text = type;
        imageItem.sprite = image;
    }

    public void ClickDetail()
    {
        GameObject spawnDetail = Instantiate(HUDDetail, parent.position, Quaternion.identity, parent);
        Transform namat = spawnDetail.transform.GetChild(0).GetChild(0).transform;
        Transform detailt = spawnDetail.transform.GetChild(0).GetChild(1).transform;
        namat.GetComponent<Text>().text = name;
        detailt.GetComponent<Text>().text = detail;
    }

    public void BuyItem()
    {
    }
}