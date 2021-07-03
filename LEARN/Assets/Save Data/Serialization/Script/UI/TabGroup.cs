using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    private List<TabButton> tabButtons;

    [SerializeField]
    private TabButton selectedButton;

    //hover,selected,exit
    public Sprite[] image;

    [SerializeField]
    private GameObject[] HUD;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTab();
        selectedButton = button;
        button.background.sprite = image[1];
        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < HUD.Length; i++)
        {
            if (i == index)
            {
                HUD[i].SetActive(true);
            }
            else
            {
                HUD[i].SetActive(false);
            }
        }
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTab();
        if (selectedButton != null || button != selectedButton)
        {
            button.background.sprite = image[0];
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTab();
    }

    public void ResetTab()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedButton != null && button == selectedButton) { continue; }
            button.background.sprite = image[2];
        }
    }

    private void Update()
    {
        selectedButton.background.sprite = image[1];
    }
}