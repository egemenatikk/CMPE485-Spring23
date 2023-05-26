using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WeaponHitTrigger : MonoBehaviour
{
    private PlayerCombat playerCombat;
    private float cooldown = 0.8f;
    private float lastCollisionTime = 0f;
    private bool isFirstAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = GetComponentInParent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCombat.getIsAttacking() && (Time.time - lastCollisionTime >= cooldown || isFirstAttack))
        {
            if (isFirstAttack) 
                isFirstAttack = false;

            if (other.CompareTag("Zombie"))
            {
                lastCollisionTime = Time.time;
                other.GetComponent<ZombieHealthController>().TakeDamage(playerCombat.getDamageAmount());
            }
        }
    }
}
