using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJoint : MonoBehaviour
{
    //Emulates a ball and socket joint, like a hip or shoulder. Constrains rigid body movement along all linear degrees of freedom, and enables all angular freedoms. Rigidbodies attached to a Character Joint orient around each axis and pivot from a shared origin.

    //are mainly used for Ragdoll effects. They are an extended ball-socket joint which allows you to limit the joint on each axis.

    private Rigidbody rb;

    public float Force;
    public string hint = "Press A to add force";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-transform.right * Force);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(transform.right * Force);
        }
    }

    private void OnGUI()
    {
        hint = GUI.TextArea(new Rect(10, 10, 200, 20), hint);
    }
}