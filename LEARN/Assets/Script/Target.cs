using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -2;

    Rigidbody rb;
    GameManager gm;


    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }



    private void OnMouseDown()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gm.UpdateScore(5);
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        gm.GameOver();
        Destroy(gameObject);
    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
