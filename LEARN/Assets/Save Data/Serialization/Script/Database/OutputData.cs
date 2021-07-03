using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputData : SaveDaata
{
    private GameObject[] HUD;

    private Text name, exp;

    private GameObject[] tierr;

    public OutputData(GameObject[] HUD, Text nameDisplay, Text expDisplay, GameObject[] tierr)
    {
        this.HUD = HUD;
        this.name = nameDisplay;
        this.exp = expDisplay;
        this.tierr = tierr;
    }

    public override Exist Update()
    {
        Load();
        if (name == null || exp == null)
        {
            HUD[0].SetActive(true);
            HUD[1].SetActive(false);
            return isHaveData = Exist.NotHaveData;
        }
        HUD[1].SetActive(true);
        HUD[0].SetActive(false);
        return isHaveData = Exist.HaveData;
    }

    public void Load()
    {
        name.text = dataPlayer.nama;
        exp.text = dataPlayer.experience;

        switch (tier)
        {
            case Tier.Rookie:
                tierr[0].gameObject.active = true;
                break;

            case Tier.Medium:
                tierr[1].gameObject.active = true;
                break;

            case Tier.Legend:
                tierr[2].gameObject.active = true;
                break;

            default:
                break;
        }
        // expDisplay.text =  database.dataPlayer.level;
    }
}