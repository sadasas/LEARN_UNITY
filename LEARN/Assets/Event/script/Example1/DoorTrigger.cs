using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)

    {
        GameEvent.current.DorWayTriggerEnter(id);
        Debug.Log("enter");
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvent.current.DoorWayExit(id);
        Debug.Log("exit");
    }
}