using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    //ublic static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
    //bool Returns true if the ray intersects with a Collider, otherwise false.

    private void FixedUpdate()
    {// This would cast rays only against colliders in layer 1
        int layerMask = 1 << 1;

        // Does the ray intersect any objects which are in the player layer.
        if (Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, layerMask))
        {
            Debug.Log("The ray hit the player");
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}