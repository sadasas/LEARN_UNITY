using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    private GameObject cube1, cube2;
    private float X;
    private float Y;
    private float Z;

    private void Awake()
    {
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        cube1.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube1.name = "Self";

        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(-0.75f, 0.0f, 0.0f);
        cube2.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        cube2.GetComponent<Renderer>().material.color = Color.green;
        cube2.name = "World";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) X = 1 - X;
        if (Input.GetKeyDown(KeyCode.Y)) Y = 1 - Y;
        if (Input.GetKeyDown(KeyCode.Z)) Z = 1 - Z;

        //1
        cube1.transform.Rotate(new Vector3(X, Y, Z), Space.Self);
        cube2.transform.Rotate(new Vector3(X, Y, Z), Space.World);

        //2
        /*cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.World);*/
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 10;
        GUI.Label(new Rect(10, 0, 0, 0), "Represents Rotation In World Space , those values are not stored in the rotation", style);
        GUI.Label(new Rect(10, 10, 0, 0), "public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo = Space.Self);", style);
        GUI.Label(new Rect(10, 20, 0, 0), "public void Rotate(Vector3 axis, float angle, Space relativeTo = Space.Self);", style);
    }
}