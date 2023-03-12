using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    private bool isSpacePressed = false;
    private float y = 10;

    public GameObject prefabToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            isSpacePressed = true;
        }
        else
        {
            isSpacePressed = false;
        }

    }

    void FixedUpdate()
    {
        if (isSpacePressed)
        {
            Instantiate(prefabToSpawn, new Vector3(110, y, 0), Quaternion.identity);
            y += 10;
        }
    }
}
