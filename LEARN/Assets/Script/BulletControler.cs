using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
  
    [SerializeField] float maxLiveTime;
    [SerializeField] ParticleSystem explosion;

    private void Start() => Destroy(gameObject, maxLiveTime);


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IHealth>().Damage(20);
        }
        ContactPoint contact = collision.GetContact(0);
        ParticleSystem exp = Instantiate(explosion, contact.point, Quaternion.identity);
        exp.Play();
        Destroy(gameObject);
    }

}
