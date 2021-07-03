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
    public List<Skin> playerSkin;
}

[Serializable]
public struct DataPlayer
{
    public String nama;
    public String level;
    public String experience;
}

[Serializable]
public struct Skin
{
    public String nameSkin;
    public String quantity;
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
    protected DataPlayer dataPlayer;

    protected Tier tier;

    protected Skin skin;

    protected Exist isHaveData;
    //protected Exist _isHaveData { get { return isHaveData; } }

    public abstract Exist Update();

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                   + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.playerData = dataPlayer;
        data.playerTier = tier;
        //data.playerSkin.Add(skin);
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
        }
        else
        {
            isHaveData = Exist.NotHaveData;
            Debug.Log("LOAD DATA: No data exist");
        }
    }
}