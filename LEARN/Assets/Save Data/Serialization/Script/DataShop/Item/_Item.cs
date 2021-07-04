using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Item : MonoBehaviour
{    //display
    [SerializeField] private Text nameItem;
    [SerializeField] private Text costItem;
    [SerializeField] private Text typeItem;

    public String type;
    public String name;
    public int cost;

    private void Start()
    {
        nameItem.text = name;
        costItem.text = cost.ToString();
        typeItem.text = type;
    }
}