
using UnityEngine;



public class BulletControler : MonoBehaviour
{
  
    [SerializeField] float maxLiveTime;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem explosion;

    private void Start() => Destroy(gameObject, maxLiveTime);


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IHealth>().Damage(damage);
        }
        ContactPoint contact = collision.GetContact(0);
        ParticleSystem exp = Instantiate(explosion, contact.point, Quaternion.identity);
        exp.Play();
        Destroy(gameObject);
    }

}
