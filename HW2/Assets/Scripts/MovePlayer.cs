using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody rb;

    private bool isWPressed = false;
    private bool isAPressed = false;
    private bool isSPressed = false;
    private bool isDPressed = false;
    private bool isSpacePressed = false;

    private float forceMagnitude = 1000f;
    private float jumpForce = 20000f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            isWPressed = true;
        }
        else
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

        if (Input.GetKeyDown(KeyCode.Space))
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
        Vector3 forceDirection = mainCamera.transform.forward;
        forceDirection.y = 0f;

        if (isWPressed)
        {
            rb.AddForce(forceDirection * forceMagnitude * Time.deltaTime);
        }

        if (isAPressed)
        {
            Vector3 forceDirectionLeft = new Vector3(0 - forceDirection.z, 0, forceDirection.x);
            rb.AddForce(Time.deltaTime * forceMagnitude * forceDirectionLeft);
        }

        if (isSPressed)
        {
            rb.AddForce((Vector3.zero - forceDirection) * forceMagnitude * Time.deltaTime);
        }

        if (isDPressed)
        {
            Vector3 forceDirectionRight = new Vector3(forceDirection.z, 0, 0 - forceDirection.x);
            rb.AddForce(Time.deltaTime * forceMagnitude * forceDirectionRight);
        }
        if (isSpacePressed)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
        }
    }
}
