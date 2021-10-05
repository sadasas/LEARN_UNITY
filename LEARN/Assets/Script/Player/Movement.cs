
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed;
    [SerializeField] float smoothRotate;
    Vector3 move;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        Steer();

    }

    void Steer()
    {
        if (move.magnitude < 0.1f) return;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        rb.MoveRotation(Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(move), smoothRotate));

    }

}
