using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTes : MonoBehaviour
{
    /////////1
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;

    public class OnSpacePressedEventArgs : EventArgs
    {
        public int spaceCount;
    }

    private int spaceCount;

    ////////2
    public delegate void TesEventDelegate(float f);

    public event TesEventDelegate OnFloatEvent;

    ///////3
    public event Action<bool, int> OnActionEvent;

    ////////4
    public UnityEvent UnityEvent;

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
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });

            OnFloatEvent?.Invoke(4.5f);
            OnActionEvent?.Invoke(true, 1);
            UnityEvent?.Invoke();
        }
    }
}