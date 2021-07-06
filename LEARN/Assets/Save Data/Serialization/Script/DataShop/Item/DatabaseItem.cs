using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Item
{
    public String name;
    public String detail;
    public TypeItem type;
    public int cost;
    public int image;
    public Owner owner;

    public Item(String name, TypeItem type, int cost, String detail, int image, Owner owner)
    {
        this.name = name;
        this.type = type;
        this.cost = cost;
        this.image = image;
        this.detail = detail;
        this.owner = owner;
    }
}

[Serializable]
public enum TypeItem
{
    COMMON,
    EPIC,
    RARE,
}

[Serializable]
public enum Owner
{
    SHOP,
    PLAYER,
}

public abstract class DatabaseItem
{
    //protected Item item;

    //protected TypeItem type;
}