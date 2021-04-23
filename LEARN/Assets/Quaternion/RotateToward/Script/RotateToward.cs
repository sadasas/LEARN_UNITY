using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToward : MonoBehaviour
{
    //Rotates a rotation from towards to

    //public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta);

    public Transform target;
    public float speed;

    private void Update()
    {
        var step = speed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
    }
}