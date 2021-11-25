using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// manage HUD edit mode and view mode
/// </summary>
public class MenuMode : MonoBehaviour
{
    bool editMode;
    [SerializeField] GameObject[] modeHUDPrefab;
    [SerializeField] Text text;
    [SerializeField] Transform parent;
    GameObject currentMode;

    private void Start()
    {
        editMode = true;
        ChooseMode();
    }

    public void ChooseMode()
    {
        if (currentMode != null) Destroy(currentMode);
        if(editMode)
        {
            GameManager.instance.gamePlay = true;
            text.text = "PLAY MODE";
            currentMode = Instantiate(modeHUDPrefab[0],parent);
            editMode = false;
        }
        else if(!editMode)
        {
            editMode = true;
            text.text = "EDIT MODE";
            currentMode  = Instantiate(modeHUDPrefab[1],parent);
            GameManager.instance.gamePlay = false;
        }
    }
}
