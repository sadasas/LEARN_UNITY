using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    //Interpolates between a and b by t and normalizes the result afterwards. The parameter t is clamped to the range [0, 1].
    //This is faster than Slerp but looks worse if the rotations are far apart.

    //public static Quaternion Lerp(Quaternion a, Quaternion b, float t);

    public Transform from;

    public Transform to;

    public float speed = 1;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, speed * Time.time);
    }
}