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
        eventTes.OnFloatEvent += Subscribe_OnFloatEvent;
        eventTes.OnActionEvent += Subscribe_OnActionEvent;
    }

    private void Subscribe_OnActionEvent(bool arg1, int arg2)
    {
        Debug.Log(arg1 + "" + arg2);
    }

    private void Subscribe_OnFloatEvent(float f)
    {
        Debug.Log("float" + f);
    }

    private void Subscribe_OnSpacePressed(object sender, EventTes.OnSpacePressedEventArgs a)
    {
        Debug.Log("space" + a.spaceCount);

        //unubscribe
        /*   EventTes eventTes = GetComponent<EventTes>();
           eventTes.OnSpacePressed -= Subscribe_OnSpacePressed;*/
    }

    public void Subscribe_UnityEvent()
    {
        Debug.Log("Unity Event");
    }
}