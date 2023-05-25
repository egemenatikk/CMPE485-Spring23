using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : StateMachineBehaviour
{
    Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 directionToPlayer = player.transform.position - animator.transform.position;
        directionToPlayer.y = 0; // Optionally, set the Y component to zero if you want to restrict rotation to the horizontal plane
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        animator.transform.rotation = lookRotation;
        //animator.transform.forward = new Vector3(-player.forward.x, player.forward.y, -player.forward.z);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 2f)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
