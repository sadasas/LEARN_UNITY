using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angle : MonoBehaviour
{
    private float angles;
    private float mouseLeftRight;
    private float mouseUpDown;
    public GameObject Top_Left;
    public GameObject Top_Right;
    public GameObject Bottom_Left;
    public GameObject Bottom_Right;

    private void Update()
    {
        angles = Vector3.Angle(transform.position, Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Debug.Log(angles);
    }
}