using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealthController : MonoBehaviour
{
    private float health= 100f;
    private Animator animator;
    public HealthBarUI healthBarUI;
    public GameObject healthBarCanvas;
    //private Rigidbody rb;
    //private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
        //characterController = GetComponent<CharacterController>();
        //characterController.enabled = false;
        healthBarUI.SetMaxHealth(health);
        
    }

    public void TakeDamage(float damageAmount) {
        health -= damageAmount;
        healthBarUI.setHealth(health);
        if (health <= 0)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<ZombieMovement>().enabled = false;
            //GetComponent<NavMeshAgent>().speed = 0.1f;
            //GetComponent<NavMeshAgent>().SetDestination(transform.position);
            //GetComponent<NavMeshAgent>().enabled = false;
            //rb.isKinematic = false;
            //healthBarUI.enabled = false;
            //characterController.enabled = true;
            healthBarCanvas.SetActive(false);
            GetComponent<ZombieHealthController>().enabled = false; 
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                animator.SetTrigger("fallBack");
            } else
            {
                animator.SetTrigger("fallForward");
            }
        }
    }

    public bool GetIsZombieDead()
    {
        return health <= 0;
    }
}
