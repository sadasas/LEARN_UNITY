using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTes : MonoBehaviour
{
    public event EventHandler OnSpacePressed;

    private void Start()
    {
        /* OnSpacePressed += Testing_OnSpacePressed;*/
    }

    private void Testing_OnSpacePressed(object sender, EventArgs a)
    {
        Debug.Log("space");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }
    }
}