using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.PlayerLoop;

[Serializable]
internal class SaveData
{
    public DataPlayer playerData;
    public Tier playerTier;
    public Inventory playerInventory;
}

[Serializable]
public struct DataPlayer
{
    public String nama;
    public int coin;
    public int experience;
}

[Serializable]
public struct Inventory
{
    public List<Item> itemPlayer;
}

[Serializable]
public enum Tier
{
    Rookie,
    Medium,
    Legend,
}

public enum Exist
{
    HaveData,
    NotHaveData,
}

public abstract class SaveDaata
{
    protected static DataPlayer dataPlayer;
    public DataPlayer _dataPlayer { get { return dataPlayer; } }

    protected static Tier tier;
    protected static Inventory inventory;
    public Inventory _inventory { get { return inventory; } }

    protected Exist isHaveData;

    public virtual Exist Update()
    {
        if (inventory.itemPlayer == null)
        {
            inventory.itemPlayer = new List<Item>();
            Debug.Log("LIST ITEM: added");
        }
        return isHaveData = Exist.NotHaveData;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                   + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.playerData = dataPlayer;
        data.playerTier = tier;
        data.playerInventory = inventory;
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            isHaveData = Exist.HaveData;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            dataPlayer = data.playerData;
            tier = data.playerTier;
            inventory = data.playerInventory;
        }
        else
        {
            isHaveData = Exist.NotHaveData;
            Debug.Log("LOAD DATA: No data exist");
        }
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/MySaveData.dat");
        }
        else
            Debug.Log("RESET DATA: No data exist");
    }
}