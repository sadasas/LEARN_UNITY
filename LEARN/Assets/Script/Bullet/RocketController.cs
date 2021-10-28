
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] int damage;
    [SerializeField] float speedCoefisient;
    [SerializeField] float maxSpeed;
   // [SerializeField] GameObject tail;


    float distance;
    Vector3 direction;

    public Transform target { get; set; }

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
      
        
    }

    private void FixedUpdate()
    {

        direction = (target.position - transform.position).normalized;
        float speed = Mathf.Clamp(distance * speedCoefisient, 0f, maxSpeed);
        rb.velocity = direction * speed;
    }
    private void Update()
    {
      

    }

    private void OnCollisionEnter(Collision collision)
    { 
        /*if(collision.collider) 
        Destroy(gameObject);*/
    }

  
}
