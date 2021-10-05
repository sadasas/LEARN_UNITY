using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    private void Update()
    {
        if (this.GetComponent<ParticleSystem>().isStopped) Destroy(gameObject);
    }
}
