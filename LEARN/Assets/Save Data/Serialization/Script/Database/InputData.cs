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
        dataPlayer.nama = name.text.ToString();
        dataPlayer.level = "0";
        dataPlayer.experience = "0";
        tier = Tier.Rookie;
        SaveGame();
    }
}