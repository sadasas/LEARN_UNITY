using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{//public void MovePosition(Vector3 position);
    //moves a Rigidbody and complies with the interpolation settings

    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 target = new Vector3(1, 0, 0);
        rb.MovePosition(transform.position + target * Time.deltaTime * speed);
    }
}