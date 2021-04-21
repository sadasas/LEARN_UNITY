using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> OnDorWayTriggerEnter;

    public event Action<int> OnDoorWayTriggerExit;

    public void DoorWayExit(int id)
    {
        if (OnDoorWayTriggerExit != null)
        {
            OnDoorWayTriggerExit(id);
        }
    }

    public void DorWayTriggerEnter(int id)
    {
        if (OnDorWayTriggerEnter != null)
        {
            OnDorWayTriggerEnter(id);
        }
    }
}