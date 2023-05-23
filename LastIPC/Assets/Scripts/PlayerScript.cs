using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public GameObject objectToSpawn;          
    public Transform throwOrigin;
    public float throwForce = 10f;
    private Vector3 lastMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        lastMoveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            Move();
            Spawn();
        }
        
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        lastMoveDirection = movement;
    }

    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
       
            GameObject spawnedObject = Instantiate(objectToSpawn, throwOrigin.position, throwOrigin.rotation);
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                rb.velocity = lastMoveDirection * 10f;
            }
        }
    }
}
