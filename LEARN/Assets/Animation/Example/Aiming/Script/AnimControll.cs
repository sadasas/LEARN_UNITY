using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControll : MonoBehaviour
{
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool aimPress = Input.GetKey(KeyCode.E);

        if (aimPress) animator.SetBool("IsAiming", true);
        else { animator.SetBool("IsAiming", false); };
    }
}
