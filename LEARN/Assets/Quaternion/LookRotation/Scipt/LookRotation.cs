using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    public Transform target;
    public int index;

    private void Update()
    {
        if (index == 1)
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }

        if (index == 2)
        {
            Quaternion rotation = Quaternion.LookRotation(target.position, Vector3.up);
            transform.rotation = rotation;
        }
    }
}