using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Akun
{
    public string name;

    public string umur;

    public string gender;
}

[CreateAssetMenu(fileName = "Database", menuName = "Database/Player", order = 1)]
public class Database : ScriptableObject
{
    public Akun akun;

    public void SetData()
    {
        PlayerPrefs.SetString("Name", akun.name);
        PlayerPrefs.SetString("Umur", akun.umur);
        PlayerPrefs.SetString("Gender", akun.gender);
    }

    public void GetData()
    {
    }
}