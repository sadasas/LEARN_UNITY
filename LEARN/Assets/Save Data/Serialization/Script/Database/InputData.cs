using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Database", menuName = "Database/ff", order = 2)]
public class InputData : SaveDaata
{
    private Text name;

    public InputData(Text name)
    {
        this.name = name;
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