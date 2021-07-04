using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class InputData : SaveDaata
{
    private Text name;

    public InputData(Text name)
    {
        this.name = name;
    }

    public override Exist Update()
    {
        return isHaveData;
    }

    public void Save()
    {
        //default
        dataPlayer.nama = name.text.ToString();
        dataPlayer.coin = 1000;
        dataPlayer.experience = 0;
        tier = Tier.Rookie;
        SaveGame();
    }

    public void Reset()
    {
        ResetData();
    }

    public void AddXP()
    {
        dataPlayer.experience += 100;
        SaveGame();
    }

    public void AddCoin()
    {
        dataPlayer.coin += 10;

        SaveGame();
    }
}