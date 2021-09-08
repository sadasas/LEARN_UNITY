using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 target { get; set; }
    public bool hit { get; set; }
    public float speed { get; set; }
    public GameObject bulletDecal { get; set; }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (!hit&& Vector3.Distance(transform.position, target) < 0.1f) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Object"))
        {
            ContactPoint point = collision.GetContact(0);
            Instantiate(bulletDecal, point.point, Quaternion.LookRotation(point.normal));
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, target);
    }

}
