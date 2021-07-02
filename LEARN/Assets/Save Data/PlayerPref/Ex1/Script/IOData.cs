using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IOData : MonoBehaviour
{
    public Database database;

    [SerializeField]
    private Text nama, gender;

    [SerializeField]
    private Text umut;

    public void SetData()
    {
        database.akun.name = nama.text.ToString();
        database.akun.umur = umut.text.ToString();
        database.akun.gender = gender.text.ToString();
        database.SetData();
    }

    public void GetData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            PlayerPrefs.GetString("Name");
            PlayerPrefs.GetString("Umur");
            PlayerPrefs.GetString("Gender");
            Debug.Log(database.akun.name);
            Debug.Log(database.akun.gender);
            Debug.Log(database.akun.umur);
        }
    }
}