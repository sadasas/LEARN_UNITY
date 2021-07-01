using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Nodelat
{
    public enum State
    {
        JALAN,
        SELESAI,
        GAGAL,
    }

    protected State _state;

    public State state { get { return _state; } }

    public abstract State Perilaku();
}