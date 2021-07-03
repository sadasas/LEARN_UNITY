using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputData : SaveDaata
{
    private GameObject[] HUD;

    private Text nameDisplay, expDisplay;

    private GameObject[] tierDisplay;

    public OutputData(GameObject[] HUD, Text nameDisplay, Text expDisplay, GameObject[] tierDisplay)
    {
        this.HUD = HUD;
        this.nameDisplay = nameDisplay;
        this.expDisplay = expDisplay;
        this.tierDisplay = tierDisplay;
    }

    public void Load()
    {
        nameDisplay.text = dataPlayer.nama;
        expDisplay.text = dataPlayer.experience;

        switch (tier)
        {
            case Tier.Rookie:
                tierDisplay[0].gameObject.active = true;
                break;

            case Tier.Medium:
                tierDisplay[1].gameObject.active = true;
                break;

            case Tier.Legend:
                tierDisplay[2].gameObject.active = true;
                break;

            default:
                break;
        }
        // expDisplay.text =  database.dataPlayer.level;
    }
}