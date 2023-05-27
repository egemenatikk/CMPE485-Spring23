using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieHitTrigger : MonoBehaviour
{
    private float cooldown = 1.5f;
    private float lastAttackTime = 0f;
    //public UnityEvent<ZombieHitTrigger> OnZombieAttack;
    
    private PlayerHealthController playerHealthController;

    // Start is called before the first frame update
    void Start()
    {
        int selectedPlayerIndex = PlayerPrefs.GetInt("selectedCharacterIndex");
        if (selectedPlayerIndex == 0)
        {
            playerHealthController = GameObject.Find("Male A").GetComponent<PlayerHealthController>();
        } else if (selectedPlayerIndex == 1)
        {
            playerHealthController = GameObject.Find("Male B").GetComponent<PlayerHealthController>();
        } else if (selectedPlayerIndex == 2)
        {
            playerHealthController = GameObject.Find("Male C").GetComponent<PlayerHealthController>();
        }

    }

    private void Update()
    {
        if (!GetComponentInParent<ZombieHealthController>().GetIsZombieDead() && playerHealthController.GetIsAlive())
        {
            if (Time.time - lastAttackTime >= cooldown && GetComponentInParent<ZombieMovement>().GetIsAttacking())
            {
                lastAttackTime = Time.time;
                playerHealthController.TakeDamage(5f);
            }
        }
    }

    /*public void ZombieAttack()
    {
        while (colliderHit.collider.GetComponent<ZombieMovement>().GetIsAttacking())
        {
            if (Time.time - lastAttackTime >= cooldown)
            {
                lastAttackTime = Time.time;
                healthController.TakeDamage(5f);
            }
        }
    }*/
}
