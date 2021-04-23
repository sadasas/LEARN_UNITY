using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Method2 : MonoBehaviour
{
    public float Speed;
    private Vector3 movement;
    public float rotationSpeed;

    private Vector3 currentPosition;

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        transform.position += transform.TransformDirection(movement * Speed * Time.deltaTime);
        // currentPosition = transform.position;
        if (movement.magnitude > 0.1)
        {
            //problem with transform rotation

            // transform.forward = movement;

            /*float y = movement.x + movement.z;
            Vector3 lookforward = new Vector3(0, y, 0);
            transform.Rotate(lookforward, Space.Self);*/

            //transform.rotation = Quaternion.LookRotation(movement);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);

            /*   Quaternion lookForward = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);
               transform.Rotate(lookForward.eulerAngles, Space.World);*/

            //transform.LookAt(transform.forward);
        }
    }
}