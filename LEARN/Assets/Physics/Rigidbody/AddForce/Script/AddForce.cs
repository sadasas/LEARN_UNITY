using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{//Force is applied continuously along the direction of the force vector. Specifying the ForceMode mode allows the type of force to be changed to an Acceleration, Impulse or Velocity Change.
    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    private Rigidbody rb;

    public float jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jump);
            Debug.Log("jump");
        }
    }
}