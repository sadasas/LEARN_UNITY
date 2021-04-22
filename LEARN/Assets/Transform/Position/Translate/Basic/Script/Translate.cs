using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public int index;

    private void Update()

    {
        if (index == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
        }

        if (index == 2)
        {
            transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        }
    }
}