using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 target { get; set; } 
    public bool hit { get; set; }

    [SerializeField] float speed;
    [SerializeField] GameObject bulletDecalPrefab;


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < 0.1f) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.GetContact(0);

        GameObject.Instantiate(bulletDecalPrefab, contact.point + contact.normal * 0.1F, Quaternion.LookRotation(contact.normal));

        Destroy(gameObject);
     

    }

    private void OnDrawGizmos()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, target );
    }

}
