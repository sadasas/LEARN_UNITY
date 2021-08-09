using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimControll : MonoBehaviour
{
    Animator animator;
    public Rig aiming;
    public float aimDuration = 0.3f;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool aimPress = Input.GetKey(KeyCode.E);

        if (aimPress)
        {
            animator.SetBool("IsAiming", true);
            aiming.weight += Time.deltaTime / aimDuration;


        }
        else
        { 
            animator.SetBool("IsAiming", false);
            aiming.weight -= Time.deltaTime / aimDuration;

        };
    }
}
