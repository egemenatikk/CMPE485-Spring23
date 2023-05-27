using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private float health = 100f;
    private Animator animator;
    public HealthBarUI healthBarUI;
    public GameObject healthBarCanvas;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        healthBarUI.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount) {
        if (!playerMovement.GetIsBlocking())
        {
            health -= damageAmount;
            healthBarUI.setHealth(health);
            
        }
        if (health <= 0)
        {
            //GetComponent<CharacterController>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerCombat>().enabled = false;
            GetComponent<ScoreCounter>().enabled = false;
            healthBarCanvas.SetActive(false);
            GetComponent<PlayerHealthController>().enabled = false;
            animator.SetTrigger("fall");
            Application.Quit();
        } else
        {
            animator.SetTrigger("getHit");
        }
    }

    public void FullHealth()
    {
        health = 100f;
        healthBarUI.setHealth(health);
    }

    public bool GetIsHealthFull()
    {
        return health == 100f;
    }

    public bool GetIsAlive()
    {
        return health > 0;
    }
}
