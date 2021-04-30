using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int itemID;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.PickupItem(itemID);
        Destroy(gameObject);
    }
}