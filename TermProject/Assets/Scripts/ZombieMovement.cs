using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    //private CharacterController characterController;
    private Transform player;
    private Transform waypoint;

    private float chaseRange = 15f;

    private bool isIdle = true;
    private bool isReturning = false;
    private bool isChasing = false;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //characterController = GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject waypoints = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in waypoints.transform)
        {
            if (gameObject.name == "Zombie1" && t.name == "Waypoint1")
            {
                waypoint = t;
            }
            else if (gameObject.name == "Zombie2" && t.name == "Waypoint2")
            {
                waypoint = t;
            }
            else if (gameObject.name == "Zombie3" && t.name == "Waypoint3")
            {
                waypoint = t;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < chaseRange)
            {
                /*Vector3 movementDirection = player.position - transform.position;
                movementDirection.y = 0;
                movementDirection.Normalize();
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime);*/
                transform.LookAt(player);
                //agent.SetDestination(player.position);
                agent.Move(transform.forward * Time.deltaTime);
                animator.SetBool("isChasing", true);
                isIdle = false;
                isChasing = true;
            }
        } else if (isReturning)
        {
            agent.SetDestination(waypoint.position);

            if (agent.remainingDistance < agent.stoppingDistance)
            {
                agent.SetDestination(transform.position);
                animator.SetBool("isWalking", false);
                isReturning = false;
                isIdle = true;
            }

            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < chaseRange)
            {
                transform.LookAt(player);
                //agent.SetDestination(player.position);
                agent.Move(transform.forward * Time.deltaTime);
                animator.SetBool("isChasing", true);
                isReturning = false;
                isChasing = true;
            } 

        } else if (isChasing)
        {
            transform.LookAt(player);
            //agent.SetDestination(player.position);
            agent.Move(transform.forward * Time.deltaTime);

            float distance = Vector3.Distance(player.position, transform.position);
            if (distance > 25f)
            {
                agent.SetDestination(waypoint.position);
                animator.SetBool("isChasing", false);
                animator.SetBool("isWalking", true);
                isChasing = false;
                isReturning = true;
            }
            else if (distance < 1f)
            {
                transform.LookAt(player);
                animator.SetBool("isAttacking", true);
                isChasing = false;
                isAttacking = true;
            }
        } else if (isAttacking)
        {
            transform.LookAt(player);
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance > 2f)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
                isChasing = true;
            }
        }
    }

    /*private void OnAnimatorMove()
    {
        Vector3 velocity = animator.deltaPosition;
        characterController.Move(velocity);
    }*/
}
