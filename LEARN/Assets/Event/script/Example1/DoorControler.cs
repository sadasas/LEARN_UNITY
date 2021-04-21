using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GameEvent.current.OnDorWayTriggerEnter += OnDoorWayOpen;
        GameEvent.current.OnDoorWayTriggerExit += OnDoorWayExit;
    }

    private void OnDoorWayOpen(int id)
    {
        if (id == this.id)
            LeanTween.moveLocalY(gameObject, 5f, 1f).setEaseInOutQuad();
    }

    private void OnDoorWayExit(int id)
    {
        if (id == this.id)
            LeanTween.moveLocalY(gameObject, 0f, 1f).setEaseInOutQuad();
    }
}