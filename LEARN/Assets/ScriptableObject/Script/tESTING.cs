using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tESTING : MonoBehaviour
{
    [SerializeField]
    private TesScriptableObject tesScriptableObject;

    [SerializeField]
    private TesScriptableObject tesScriptableObject2;

    private void Start()
    {
        Debug.Log(tesScriptableObject.Myatring);
        Debug.Log(tesScriptableObject2.Myatring);
    }
}