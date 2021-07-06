using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputData : DatabasePlayer
{
    private GameObject[] HUD;

    private Text name, exp, coin;

    private GameObject[] tierr;

    public OutputData(GameObject[] HUD, Text nameDisplay, Text expDisplay, GameObject[] tierr, Text coin)
    {
        this.HUD = HUD;
        this.name = nameDisplay;
        this.exp = expDisplay;
        this.tierr = tierr;
        this.coin = coin;
    }

    public override Exist Update()
    {
        LoadGame();
        Load();

        if (isHaveData == Exist.NotHaveData)
        {
            HUD[0].SetActive(true);
            HUD[1].SetActive(false);

            return isHaveData = Exist.NotHaveData;
        }
        else
        {
            base.Update();
        }

        HUD[0].SetActive(false);
        HUD[1].SetActive(true);

        return isHaveData = Exist.HaveData;
    }

    public void Load()
    {
        name.text = dataPlayer.nama;
        exp.text = dataPlayer.experience.ToString();
        coin.text = dataPlayer.coin.ToString();

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
    }
}