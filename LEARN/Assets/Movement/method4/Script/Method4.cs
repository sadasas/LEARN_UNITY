using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Method4 : MonoBehaviour
{
    //The velocity vector of the rigidbody. It represents the rate of change of Rigidbody position.
    private Rigidbody rb;

    private Vector3 movement;

    public float speed;

    private float vertical;
    private float horizontal;
    private Vector3 input;
    private Vector3 inputDir;
    private Vector3 moveAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir = movement.normalized;
        moveAmount = (inputDir * speed);

        /* input = transform.right * horizontal + transform.forward * vertical;
         inputDir = input.normalized;
         moveAmount = (inputDir * speed);*/
    }

    private void FixedUpdate()
    {
        rb.velocity = moveAmount;

        if (inputDir.magnitude > 0.1f)
        {
            /*transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), 0.5f);*/
        }
    }
}