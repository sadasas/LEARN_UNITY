using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDDetail : MonoBehaviour
{
    public _Item item;

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}