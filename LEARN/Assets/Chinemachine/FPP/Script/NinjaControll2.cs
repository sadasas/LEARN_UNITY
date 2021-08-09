using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControll2 : MonoBehaviour
{
    float speed = 2f;
    CharacterController cr;
    Animator anim;
    public Transform cam;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cr = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if(direction.magnitude>0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 movDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            cr.Move(movDir.normalized * speed * Time.deltaTime);
            anim.SetBool("IsWalking", true);
            
        }

        else
        {
            anim.SetBool("IsWalking", false);

        }
    }
}
