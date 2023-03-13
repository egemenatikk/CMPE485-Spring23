using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private bool isWPressed = false;
    private bool isAPressed = false;
    private bool isSPressed = false;
    private bool isDPressed = false;

    private float upDownForce = 750f;
    private float leftRightForce = 500f;

    public Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            isWPressed = true;
        } else
        {
            isWPressed = false;
        }

        if (Input.GetKey("a"))
        {
            isAPressed = true;
        }
        else
        {
            isAPressed = false;
        }

        if (Input.GetKey("s"))
        {
            isSPressed = true;
        }
        else
        {
            isSPressed = false;
        }

        if (Input.GetKey("d"))
        {
            isDPressed = true;
        }
        else
        {
            isDPressed = false;
        }

    }

    void FixedUpdate()
    {
        if (isWPressed)
        {
            rb.AddForce(-upDownForce * Time.deltaTime, 0, 0);
        }

        if (isAPressed)
        {
            rb.AddForce(0, 0, -leftRightForce * Time.deltaTime);
        }

        if (isSPressed)
        {
            rb.AddForce(upDownForce * Time.deltaTime, 0, 0);
        }

        if (isDPressed)
        {
            rb.AddForce(0, 0, leftRightForce * Time.deltaTime);
        }
    }
}
