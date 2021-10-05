using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEvent : MonoBehaviour
{
    public Action<int> shootEvent;
    public Func<bool,bool> healingEvent;

}
