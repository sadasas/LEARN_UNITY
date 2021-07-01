using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleNode : Nodelat
{
    private Transform target;

    private Transform origin;

    public IdleNode(Transform target, Transform origin)
    {
        this.target = target;
        this.origin = origin;
    }

    public override State Perilaku()
    {
        float distance = Vector3.Distance(target.position, origin.position);
        if (distance <= 1)
        {
            Debug.Log("JALAN");
            return State.JALAN;
        }
        return State.GAGAL;
    }
}