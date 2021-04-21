using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private void Start()
    {
        EventTes eventTes = GetComponent<EventTes>();
        eventTes.OnSpacePressed += Subscribe_OnSpacePressed;
    }

    private void Subscribe_OnSpacePressed(object sender, EventArgs a)
    {
        Debug.Log("space");

        //unubscribe
        /*   EventTes eventTes = GetComponent<EventTes>();
           eventTes.OnSpacePressed -= Subscribe_OnSpacePressed;*/
    }
}