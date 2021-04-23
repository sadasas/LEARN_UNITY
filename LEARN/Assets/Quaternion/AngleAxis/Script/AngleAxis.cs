using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAxis : MonoBehaviour
{
    //Creates a rotation which rotates angle degrees around axis.
    // public static Quaternion AngleAxis(float angle, Vector3 axis);
    public float angle;

    private void Update()
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}