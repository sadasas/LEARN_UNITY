using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateControl : MonoBehaviour
{
    private Animator animator;

    //bool
    private int isWalkingToHash;

    //blend tree

    private float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decceleration = 0.5f;
    private int velocityIntoHash;

    private void Start()
    {
        animator = GetComponent<Animator>();

        //bool
        // isWalkingToHash = Animator.StringToHash("isWalking");

        //blend tree
        velocityIntoHash = Animator.StringToHash("Velocity");
    }

    private void Update()
    {
        #region Bool

        /*   bool isWalking = animator.GetBool(isWalkingToHash);
           bool isRunning = animator.GetBool("isRunning");
           bool forwardPressed = Input.GetKey("w");
           bool runPressed = Input.GetKey("left shift");

           if (!isWalking && forwardPressed)
           {
               animator.SetBool("isWalking", true);
           }
           if (isWalking && !forwardPressed)
           {
               animator.SetBool("isWalking", false);
           }

           if (!isRunning && (forwardPressed && runPressed))
           {
               animator.SetBool("isRunning", true);
           }
           if (isRunning && (!forwardPressed || !runPressed))
           {
               animator.SetBool("isRunning", false);
           }*/

        #endregion Bool

        #region Blend Tree

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * decceleration;
        }

        if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        animator.SetFloat(velocityIntoHash, velocity);

        #endregion Blend Tree
    }
}