using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLData : MonoBehaviour
{
    [SerializeField] private SaveDaata database;

    //HUD
    [SerializeField] private GameObject[] HUD;

    //Input
    [SerializeField] private Text name;

    //Display
    public Text nameDisplay, expDisplay;

    public GameObject[] tierDisplay;

    private void Awake()
    {
        database.LoadGame();
        Load();
    }

    private void Update()
    {
        if (database._isHaveData == Exist.HaveData)
        {
            HUD[1].SetActive(true);
            HUD[0].SetActive(false);
        }
        else
        {
            HUD[0].SetActive(true);
            HUD[1].SetActive(false);
        }
    }

    public void Save()
    {
        database.dataPlayer.nama = name.text.ToString();
        database.dataPlayer.level = "0";
        database.dataPlayer.experience = "0";
        database.tier = Tier.Rookie;
        database.SaveGame();
        database.LoadGame();
        Load();
    }

    public void Load()
    {
        nameDisplay.text = database.dataPlayer.nama;
        expDisplay.text = database.dataPlayer.experience;

        switch (database.tier)
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