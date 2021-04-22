using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    #region EulerAngles

    [SerializeField]
    private float rotationSpeed = 45f;

    private Vector3 CurrentEulerAngles;
    private float X;
    private float Y;
    private float Z;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) X = 1 - X;
        if (Input.GetKeyDown(KeyCode.Y)) Y = 1 - Y;
        if (Input.GetKeyDown(KeyCode.Z)) Z = 1 - Z;

        CurrentEulerAngles += new Vector3(X, Y, Z) * Time.deltaTime * rotationSpeed;

        transform.eulerAngles = CurrentEulerAngles;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 10;
        GUI.Label(new Rect(10, 0, 0, 0), "Represents Rotation In World Space , those values are not stored in the rotation", style);
        GUI.Label(new Rect(10, 10, 0, 0), "Press X to rotate X", style);
        GUI.Label(new Rect(10, 20, 0, 0), "Press Y to rotate Y", style);
        GUI.Label(new Rect(10, 30, 0, 0), "Press Z to rotate Z", style);
        GUI.Label(new Rect(10, 45, 0, 0), "Rotating on X:" + X + " Y:" + Y + " Z:" + Z, style);

        GUI.Label(new Rect(10, 55, 0, 0), "Transform.eulerAngle: " + transform.eulerAngles, style);
    }

    #endregion EulerAngles
}