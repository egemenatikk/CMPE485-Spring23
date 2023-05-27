using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    public int numberOfClicks = 0;
    private float lastClickedTime = 0;
    private float maxComboDelay = 1.75f;
    private bool isAttacking = false;
    private float damageAmount = 10f;

    [SerializeField]
    private float cooldownTime;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && Time.time - lastClickedTime >= 1f)
        {
            if (Time.time - lastClickedTime > maxComboDelay)
            {
                numberOfClicks = 0;
            }
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    { 
        lastClickedTime = Time.time;
        numberOfClicks++;
        numberOfClicks %= 3;
        
        animator.SetLayerWeight(animator.GetLayerIndex("Combat Layer"), 1);
        isAttacking = true;

        if (numberOfClicks == 1)
        {
            animator.SetTrigger("attack1");
            damageAmount = 10f;
        }
        if (numberOfClicks == 2)
        {
            animator.SetTrigger("attack2");
            damageAmount = 15f;
        }
        if (numberOfClicks == 0)
        {
            animator.SetTrigger("attack3");
            damageAmount = 20f;
        }

        yield return new WaitForSeconds(0.8f);

        animator.SetLayerWeight(animator.GetLayerIndex("Combat Layer"), 0);
        isAttacking = false;

    }
    public bool getIsAttacking()
    {
        return isAttacking;
    }

    public float getDamageAmount()
    {
        return damageAmount;
    }
}
