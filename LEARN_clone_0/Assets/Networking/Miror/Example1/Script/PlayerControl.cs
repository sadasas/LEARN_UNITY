using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}