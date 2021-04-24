using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotation : MonoBehaviour
{
    //public void MoveRotation(Quaternion rot);
    //if Rigidbody interpolation is enabled on the Rigidbody, calling Rigidbody.MoveRotation will resulting in a smooth transition between the two rotations in any intermediate frames rendered. This should be used if you want to continuously rotate a rigidbody in each FixedUpdate.

    private Rigidbody rb;
    private Vector3 angularVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        angularVelocity = new Vector3(0, 100, 0);
    }

    private void FixedUpdate()
    {
        Quaternion delta = Quaternion.Euler(angularVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * delta);
    }
}