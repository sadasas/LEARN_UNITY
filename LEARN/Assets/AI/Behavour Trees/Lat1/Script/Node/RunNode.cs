using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunNode : Nodelat

{
    private Transform target;

    private Transform origin;

    public RunNode(Transform target, Transform origin)
    {
        this.target = target;
        this.origin = origin;
    }

    public override State Perilaku()
    {
        if (target == null || origin == null)
        {
            return State.GAGAL;
        }
        float distance = Vector3.Distance(target.position, origin.position);
        if (distance <= 1)
        {
            Debug.Log("LARI");
            return State.JALAN;
        }

        return State.SELESAI;
    }
}