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
        int selectedPlayerIndex = PlayerPrefs.GetInt("selectedCharacterIndex"); 
        if (selectedPlayerIndex == 0)
        {
            GameObject.Find("Male B").SetActive(false);
            GameObject.Find("Male C").SetActive(false);
        } else if (selectedPlayerIndex == 1)
            {
                GameObject.Find("Male A").SetActive(false);
                GameObject.Find("Male C").SetActive(false);
        } else if (selectedPlayerIndex == 2)
        {
            GameObject.Find("Male A").SetActive(false);
            GameObject.Find("Male B").SetActive(false);
        }


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
