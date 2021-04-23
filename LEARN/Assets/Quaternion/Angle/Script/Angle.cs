using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{
    //returns the angle in degrees between two rotations a and b.
    //public static float Angle(Quaternion a, Quaternion b);

    public Transform target;

    private void Update()
    {
        float angles = Quaternion.Angle(transform.rotation, target.rotation);

        Debug.Log(angles);
    }
}