using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerControll : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    int IDJumpTohHash;
    int IDGroundTohHash;
    int IDVelocityToHash;

    [SerializeField] float moveSpeed;
    [SerializeField] float animSpeed;
    [Range(0,1)]
    [SerializeField] float rotateSpeed;

    Vector3 movementInput;
  
    [SerializeField]
    float currentVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        IDVelocityToHash = Animator.StringToHash("Velocity");
        IDGroundTohHash = Animator.StringToHash("IsGrounded");
        IDGroundTohHash = Animator.StringToHash("IsJump");

    }

    private void Update()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {
         movementInput = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        movementInput.Normalize();

        characterController.Move(movementInput * moveSpeed * Time.deltaTime);
    }

    void RotatePlayer()
    {
        if(movementInput.magnitude>0.1f)
        {
            currentVelocity += Time.deltaTime * animSpeed;
          


            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementInput), rotateSpeed);
        }

        else
        {
            if(currentVelocity>0.0f)
            {
                currentVelocity -= Time.deltaTime * animSpeed;

            }
            else
            {
                currentVelocity = 0.0f;
            }    
        }



        animator.SetFloat(IDVelocityToHash, currentVelocity);
    }
}
