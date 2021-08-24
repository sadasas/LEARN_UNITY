using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager :MonoBehaviour
{
   public AmmoScriptableObject contentsAmmo;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<InventoryPlayer>().AddAmmo(this);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
