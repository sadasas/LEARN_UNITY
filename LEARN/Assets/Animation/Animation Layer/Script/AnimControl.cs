using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    private Vector3 inputMove;
    private int velocityToHash;

    private int smashToHash;
    private int uppercutToHash;

    private int isWalkingToHash;
    private int isJumpingToHash;

    private int isKick1ToHash;
    private int isKick2ToHash;

    private bool isSmash;
    private bool isUppercut;

    private bool isKick1;
    private bool isKick2;

    private bool isJumping;
    private float distoGround;

    public LayerMask ground;
    public float acceleration = 0.1f;
    public float deceeleration = 0.3f;
    public float speed = 1f;
    public float velocity = 0.0f;
    public float maxWalkVelocity = 1.0f;

    [Range(0, 1)]
    public float distanceToGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        velocityToHash = Animator.StringToHash("Velocity");
        smashToHash = Animator.StringToHash("Smash");
        uppercutToHash = Animator.StringToHash("Uppercut");
        isWalkingToHash = Animator.StringToHash("isWalking");
        isJumpingToHash = Animator.StringToHash("isJump");
        isKick1ToHash = Animator.StringToHash("Kick1");
        isKick2ToHash = Animator.StringToHash("Kick2");
        distoGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        inputMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputMove.Normalize();

        isSmash = animator.GetBool(smashToHash);
        isUppercut = animator.GetBool(uppercutToHash);

        isKick1 = animator.GetBool(isKick1ToHash);
        isKick2 = animator.GetBool(isKick2ToHash);

        isJumping = animator.GetBool(isJumpingToHash);

        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, distoGround + 0.3f, ground);

        //upperAttack
        bool smashPressed = Input.GetKey(KeyCode.E);
        bool uppercutComboPressed = Input.GetKey(KeyCode.G);

        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        //lowerAttack
        bool kick1Pressed = Input.GetKey(KeyCode.L);
        bool kick2Pressed = Input.GetKey(KeyCode.O);

        if (Input.GetKey(KeyCode.P)) Injured();

        if (!isUppercut && smashPressed && !LowerAttackRunning())
        {
            animator.SetBool(smashToHash, true);
        }

        if (!isSmash && uppercutComboPressed && !LowerAttackRunning())
        {
            animator.SetBool(uppercutToHash, true);
        }

        if (!isKick2 && kick1Pressed && !UpperAttackRunning())
        {
            animator.SetBool(isKick1ToHash, true);
        }

        if (!isKick1 && kick2Pressed && !UpperAttackRunning())
        {
            animator.SetBool(isKick2ToHash, true);
        }

        if (jumpPressed && Animating() == false && isGrounded)
        {
            animator.SetBool("isJump", true);
        }
        if (!jumpPressed)
        {
            animator.SetBool("isJump", false);
        }
    }

    private void FixedUpdate()
    {
        if (Animating() == false)
        {
            animator.SetFloat(velocityToHash, velocity);
            rb.MovePosition(transform.position + inputMove * Time.deltaTime * speed);
            if (inputMove.magnitude > 0.1)
            {
                /* if (velocity <= maxWalkVelocity)
                 {
                     velocity += Time.deltaTime * acceleration;
                 }*/
                animator.SetBool(isWalkingToHash, true);
                rb.rotation = Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(inputMove), 0.5f);
            }
            else
            {
                animator.SetBool(isWalkingToHash, false);
                /*  if (velocity >= 0.0f)
                  {
                      velocity -= Time.deltaTime * deceeleration;
                  }*/
            }
        }

        /*  if (velocity > 1.0f)
          {
              velocity = 1.0f;
          }
          if (velocity < 0.0f)
          {
              velocity = 0.0f;
          }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine((animator.GetIKPosition(AvatarIKGoal.LeftFoot)), Vector3.down);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot , 1f);
            RaycastHit hit;
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, distanceToGround + 1f, ground))
            {
                if (hit.transform.tag == "Walkable")
                {
                    Vector3 footPosition = hit.point;
                    footPosition.y += distanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
                }
            }

            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
            if(Physics.Raycast(ray,out hit,distanceToGround+1f,ground))
            {
                if (hit.transform.tag == "Walkable")
                {
                    Vector3 footPosition = hit.point;
                    footPosition.y += distanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));
                }

            }
         
        }
    }

    public bool Animating()
    {
        if (isSmash || isUppercut || isJumping)
        {
            Debug.Log("ANIMATING : RUNNING");
            return true;
        }
        Debug.Log("ANIMATING : COMPLETE");

        return false;
    }

    public bool UpperAttackRunning()
    {
        if (isSmash || isUppercut)
        {
            return true;
        }
        return false;
    }

    public bool LowerAttackRunning()
    {
        if (isKick1 || isKick2)
        {
            return true;
        }
        return false;
    }

    private void Injured()
    {
        animator.SetLayerWeight(1, 100);
    }
}