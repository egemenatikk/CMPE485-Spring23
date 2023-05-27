using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChecker : MonoBehaviour
{
    private bool isKeyObtained = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        Debug.Log(other.name);
        if (isKeyObtained && other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Application.Quit();
            
        }
    }

    public void KeyObtained ()
    {
        isKeyObtained = true;
    }
}
