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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBarUI.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount) {
        health -= damageAmount;
        healthBarUI.setHealth(health);
        if (health <= 0)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<ZombieMovement>().enabled = false;
            //GetComponent<NavMeshAgent>().enabled = false;
            //healthBarUI.enabled = false;
            healthBarCanvas.SetActive(false); ;
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
}
