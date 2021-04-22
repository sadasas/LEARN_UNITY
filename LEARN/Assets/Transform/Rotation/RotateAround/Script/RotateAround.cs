using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject Target;

    private void Update()
    {
        transform.RotateAround(Target.transform.position, -Vector3.up, 20 * Time.deltaTime);
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 10;
        GUI.Label(new Rect(10, 0, 0, 0), "Rotates the transform about axis passing through point in world coordinates by angle degrees.", style);
        GUI.Label(new Rect(10, 10, 0, 0), "public void RotateAround(Vector3 point, Vector3 axis, float angle)", style);
    }
}