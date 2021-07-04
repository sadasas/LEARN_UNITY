using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public String name;
    public TypeItem type;
    public int cost;

    public Item(String name, TypeItem type, int cost)
    {
        this.name = name;
        this.type = type;
        this.cost = cost;
    }
}

public enum TypeItem
{
    COMMON,
    EPIC,
    RARE,
}

public enum DatabaseAdded
{
    DATABASE_AXIST,
    DATABASE_NOT_EXIST,
}

public struct ItemInShop
{
    public List<Item> allItemInSHOP;
}

public abstract class DatabaseShop
{
    protected Item item;

    protected TypeItem type;
    private DatabaseAdded isExist;
    protected DatabaseAdded _isExist { get { return isExist; } }
    protected static ItemInShop _allItem { get { return allitem; } }
    protected static ItemInShop allitem;

    public abstract void Update();

    public virtual DatabaseAdded CeckItemDatabase()
    {
        if (isExist == DatabaseAdded.DATABASE_NOT_EXIST || allitem.allItemInSHOP == null)
        {
            allitem.allItemInSHOP = new List<Item>();
            Debug.Log("DATABASE: database added");
        }

        return isExist = DatabaseAdded.DATABASE_AXIST;
    }
}