using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreCounter scoreCounter = other.GetComponent<ScoreCounter>();

        if (scoreCounter != null)
        {
            Debug.Log(gameObject.name);
            if (gameObject.name.StartsWith("Pink") || gameObject.name.StartsWith("Purple"))
            {
                scoreCounter.CollectibleCollected(150);
            } else if (gameObject.name.StartsWith("Brown"))
            {
                scoreCounter.CollectibleCollected(250);
            } else if (gameObject.name.StartsWith("Black") || gameObject.name.StartsWith("White") || gameObject.name.StartsWith("Orange"))
            {
                scoreCounter.CollectibleCollected(350);
            } else if (gameObject.name.StartsWith("Yellow"))
            {
                scoreCounter.CollectibleCollected(500);
            } else if (gameObject.name.StartsWith("Blue") || gameObject.name.StartsWith("Green"))
            {
                scoreCounter.CollectibleCollected(750);
            }

            gameObject.SetActive(false);
        }
    }
}
