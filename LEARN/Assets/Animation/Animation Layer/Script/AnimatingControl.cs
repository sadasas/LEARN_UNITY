using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingControl : StateMachineBehaviour
{
    public string boolConnected;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boolConnected == "Smash")
        {
            animator.SetBool(boolConnected, false);
        }
        else if (boolConnected == "Uppercut")
        {
            animator.SetBool(boolConnected, false);
        }
        else if (boolConnected == "isJump")
        {
            animator.SetBool(boolConnected, false);
        }
        else if (boolConnected == "Kick1")
        {
            animator.SetBool(boolConnected, false);
        }
        else if (boolConnected == "Kick2")
        {
            animator.SetBool(boolConnected, false);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}