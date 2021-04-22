using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;
    private Vector3 Direction;

    private void Update()
    {
        Direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Direction.Normalize();
    }

    private void FixedUpdate()
    {
        transform.Translate(Direction * Time.deltaTime * speed, Space.World);

        if (Direction.magnitude > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direction), 2f);
        }
    }
}