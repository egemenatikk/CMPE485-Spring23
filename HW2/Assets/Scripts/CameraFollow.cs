using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float smoothness = 5f;
    private Vector3 offset = new Vector3(0, 2f, -5f);


    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
        transform.rotation = player.rotation;
    }

    void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        transform.RotateAround(player.position, Vector3.up, horizontalRotation * smoothness);
        transform.RotateAround(player.position, transform.right, -verticalRotation * smoothness);

        Vector3 cameraOffset = -transform.forward * 5f;

        transform.position = player.position + cameraOffset;
        transform.LookAt(player.position);

    }
}
