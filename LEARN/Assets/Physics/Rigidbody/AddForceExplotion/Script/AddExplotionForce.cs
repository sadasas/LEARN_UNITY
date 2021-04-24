using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExplotionForce : MonoBehaviour
{//public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0.0f, ForceMode mode = ForceMode.Force));
    //Applies a force to a rigidbody that simulates explosion effects.
    public float radius = 5.0F;

    public float power = 10.0F;
    private Rigidbody rbb;

    private void Start()
    {
        rbb = GetComponent<Rigidbody>();
        rbb.isKinematic = true;
    }

    private void Update()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
}