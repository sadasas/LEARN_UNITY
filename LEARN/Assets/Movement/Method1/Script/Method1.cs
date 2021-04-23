using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Method1 : MonoBehaviour
{
    public float Speed;
    private Vector3 Movement;

    private void Update()
    {
        Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//Input System
        Movement.Normalize();//Normalized all input to magnitude 1
    }

    private void FixedUpdate()
    {
        transform.Translate(Movement * Speed * Time.deltaTime, Space.World);

        if (Movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Movement), 0.5f);
        }
    }
}