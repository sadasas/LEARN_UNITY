using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    private Vector3 inputMove;
    private int velocityToHash;
    private Rigidbody rb;

    public float acceleration = 0.1f;
    public float deceeleration = 0.3f;
    public float speed = 1f;
    public float velocity = 0.0f;

    public float maxWalkVelocity = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        velocityToHash = Animator.StringToHash("Velocity");
    }

    private void Update()
    {
        inputMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputMove.Normalize();
        bool smashPressed = Input.GetKey(KeyCode.E);
        bool uppercutCombo = Input.GetKey(KeyCode.G);

        animator.SetFloat(velocityToHash, velocity);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + inputMove * Time.deltaTime * speed);
        if (inputMove.magnitude > 0.1)
        {
            if (velocity <= maxWalkVelocity)
            {
                velocity += Time.deltaTime * acceleration;
            }

            //transform.rotation = Quaternion.LookRotation()
        }
        else
        {
            if (velocity >= 0.0f)
            {
                velocity -= Time.deltaTime * deceeleration;
            }
        }

        if (velocity > 1.0f)
        {
            velocity = 1.0f;
        }
        if (velocity < 0.0f)
        {
            velocity = 0.0f;
        }
    }
}