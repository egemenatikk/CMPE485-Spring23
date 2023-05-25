using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieWalkState : StateMachineBehaviour
{
    Transform waypoint;
    NavMeshAgent agent;
    GameObject player;
    float chaseRange = 8f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = animator.GetComponent<NavMeshAgent>();
        
        GameObject waypointss = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in waypointss.transform)
        {
            if (animator.gameObject.name == "Zombie1" && t.name == "Waypoint1")
            {
                waypoint = t;
            } else if (animator.gameObject.name == "Zombie2" && t.name == "Waypoint2")
            {
                waypoint = t;
            } else if (animator.gameObject.name == "Zombie3" && t.name == "Waypoint3")
            {
                waypoint = t;
            }
        }
        agent.SetDestination(waypoint.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            animator.SetBool("isWalking", false);
        }
        float distance = Vector3.Distance(player.transform.position, animator.transform.position);
        if (distance < chaseRange)
        {
            Vector3 directionToPlayer = player.transform.position - animator.transform.position;
            directionToPlayer.y = 0; // Optionally, set the Y component to zero if you want to restrict rotation to the horizontal plane
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            animator.transform.rotation = lookRotation;
            //animator.transform.forward = new Vector3(-player.transform.forward.x, player.transform.forward.y, -player.transform.forward.z);
            //agent.SetDestination(player.transform.position);
            agent.Move(Time.deltaTime * animator.transform.forward);
            animator.SetBool("isChasing", true);
        } else
        {
            agent.SetDestination(waypoint.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
