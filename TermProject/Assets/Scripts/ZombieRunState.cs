using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieRunState : StateMachineBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 directionToPlayer = player.transform.position - animator.transform.position;
        directionToPlayer.y = 0; // Optionally, set the Y component to zero if you want to restrict rotation to the horizontal plane
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        animator.transform.rotation = lookRotation;
        //animator.transform.forward = new Vector3(-player.transform.forward.x, player.transform.forward.y, -player.transform.forward.z);
        //agent.SetDestination(player.transform.position);
        agent.Move(Time.deltaTime * animator.transform.forward);
        //agent.SetDestination(player.position);
        float distance = Vector3.Distance(player.transform.position, animator.transform.position);
        if (distance > 10f)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isWalking", true);
        }
        else if (distance < 1f)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
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
