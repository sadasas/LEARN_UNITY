using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum DatabaseAdded
{
    DATABASE_AXIST,
    DATABASE_NOT_EXIST,
}

[Serializable]
public struct ItemInShop
{
    public List<Item> allItemInSHOP;
}

public abstract class DatabaseShop
{
    private DatabaseAdded isExist;
    protected DatabaseAdded _isExist { get { return isExist; } }
    protected static ItemInShop _allItem { get { return allitem; } }
    protected static ItemInShop allitem;

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