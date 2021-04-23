using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp : MonoBehaviour
{
    //Spherically interpolates between quaternions a and b by ratio t. The parameter t is clamped to the range [0, 1].

    public Transform from;

    public Transform to;
    public float count;

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, count);
        count = count + Time.deltaTime;
    }
}