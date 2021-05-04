using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Unity FSM"), menuName = ("State/ Idle"))]
public class IdleStat : AbstracFMS
{
    public override bool EnterState()
    {
        Debug.Log("enter");
        base.EnterState();
        return true;
    }

    public override void UpdateState()
    {
        Debug.Log("updating");
    }

    public override bool ExitState()
    {
        Debug.Log("exit");
        base.ExitState();
        return true;
    }
}