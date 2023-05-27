using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollisionChecker : MonoBehaviour
{
    private EndGameChecker endGameChecker;

    void Start()
    {
        endGameChecker = GameObject.Find("FinishPoint").GetComponent<EndGameChecker>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameChecker.KeyObtained();
            gameObject.SetActive(false);
        }
    }
}
