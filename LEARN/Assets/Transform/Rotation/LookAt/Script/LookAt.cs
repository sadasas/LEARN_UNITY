using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.LookAt(target, Vector3.left);
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 10;
        GUI.Label(new Rect(10, 0, 0, 0), "Rotates the transform so the forward vector points at /target/'s current position or world position", style);
        GUI.Label(new Rect(10, 10, 0, 0), "public void LookAt(Transform target)", style);
        GUI.Label(new Rect(10, 20, 0, 0), "public void LookAt(Transform target, Vector3 worldUp = Vector3.up)", style);
        GUI.Label(new Rect(10, 30, 0, 0), "public void LookAt(Vector3 worldPosition)", style);
        GUI.Label(new Rect(10, 40, 0, 0), "public void LookAt(Vector3 worldPosition, Vector3 worldUp = Vector3.up)", style);
    }
}