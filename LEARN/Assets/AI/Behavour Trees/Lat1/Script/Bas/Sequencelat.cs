using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Sequencelat : Nodelat
{
    private List<Nodelat> nodes = new List<Nodelat>();

    public Sequencelat(List<Nodelat> nodes)
    {
        this.nodes = nodes;
    }

    public override State Perilaku()
    {
        bool isRunning = false;
        foreach (var nodelat in nodes)
        {
            switch (nodelat.Perilaku())
            {
                case State.JALAN:
                    isRunning = true;
                    break;

                case State.SELESAI:

                    break;

                case State.GAGAL:
                    _state = State.GAGAL;
                    return _state;

                default:
                    break;
            }
        }

        return isRunning ? State.JALAN : State.SELESAI;
    }
}