using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    private bool isPPressed = false;

    public GameObject prefabToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            isPPressed = true;
        }
        else
        {
            isPPressed = false;
        }

    }

    void FixedUpdate()
    {
        if (isPPressed)
        {
            Instantiate(prefabToSpawn, prefabToSpawn.transform.position, Quaternion.identity);
        }
    }
}
