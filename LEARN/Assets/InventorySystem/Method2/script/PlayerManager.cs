using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 movemenet;
    public float speed;

    private void Update()
    {
        movemenet = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movemenet.Normalize();
    }

    private void FixedUpdate()
    {
        transform.Translate(movemenet * speed * Time.deltaTime, Space.World);
    }
}