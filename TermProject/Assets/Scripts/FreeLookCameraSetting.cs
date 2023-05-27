using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCameraSetting : MonoBehaviour
{
    private CinemachineFreeLook cinemachineFreeLook;
    private Transform cameraFocusTransform;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineFreeLook = GetComponentInParent<CinemachineFreeLook>();
        cameraFocusTransform = GameObject.FindGameObjectWithTag("CameraFocus").transform;
        cinemachineFreeLook.Follow = cameraFocusTransform;
        cinemachineFreeLook.LookAt = cameraFocusTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
