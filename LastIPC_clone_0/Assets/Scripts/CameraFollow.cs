using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                 
    public Vector3 offset = new Vector3(0f, 2f, -5f);   

    public float smoothSpeed = 0.125f;       
    public float rotationSpeed = 3f;         

    private Vector3 desiredPosition;        

    private void LateUpdate()
    {    
        desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Quaternion rotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
