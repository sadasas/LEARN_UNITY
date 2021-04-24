using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Method5 : MonoBehaviour
{
    //Adds a force to the Rigidbody.
    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
    //pecifying the ForceMode mode allows the type of force to be changed to an Acceleration, Impulse or Velocity Change.

    private Rigidbody rb;
    public float speed;
    private Vector3 movement;
    private Vector3 inputAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement.Normalize();
        inputAmount = (movement * speed);
    }

    private void FixedUpdate()
    {
        rb.AddForce(inputAmount);
    }
}