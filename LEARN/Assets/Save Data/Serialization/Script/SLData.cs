using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLData : MonoBehaviour
{
    private InputData inputData;
    private OutputData outputData;
    private SaveDaata database;

    //Input
    [SerializeField] private Text namePlayer;

    //Output
    [SerializeField] private Text namePlayerDisplay, expPlayerDisplay;

    [SerializeField] private GameObject[] tierDisplay, HUD;

    private void Start()
    {
        outputData.Load();
    }

    private void Awake()
    {
        inputData = new InputData(namePlayer);
        outputData = new OutputData(HUD, namePlayerDisplay, expPlayerDisplay, tierDisplay);
    }

    private void Update()
    {
        database.Update();
    }

    public void SaveDataPlayer()
    {
        inputData.Save();
    }

    public void LoadDataPlayer()
    {
        outputData.Load();
    }
}