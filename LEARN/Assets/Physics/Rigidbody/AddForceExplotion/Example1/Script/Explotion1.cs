using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion1 : MonoBehaviour
{
    public float force;
    public float radius;
    private Rigidbody rb;
    private Vector3 explotionPos;
    public ParticleSystem ps;
    private bool colapse = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        explotionPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] coliders = Physics.OverlapSphere(explotionPos, radius);

        foreach (Collider hit in coliders)
        {
            if (hit.GetComponent<Rigidbody>())
            {
                Rigidbody rbHit = hit.GetComponent<Rigidbody>();
                rbHit.AddExplosionForce(force, explotionPos, radius, 3f);
                Debug.Log("dorr");
                if (!colapse)
                {
                    GameObject prs = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
                    Destroy(prs, 1);
                    colapse = true;
                }
            }
        }

        Destroy(gameObject);

        /*rb.AddExplosionForce(force, transform.position, radius, 3.0f);*/
    }
}