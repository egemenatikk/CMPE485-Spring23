using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMovingPlatform : MonoBehaviour
{
    private float deltaZ = 0.05f;
    private float waitDuration = 0.03f;
    
    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            transform.position = transform.position + new Vector3(0, 0, deltaZ);
            if ((transform.position.z > 160f) || (transform.position.z < 146f))
                deltaZ = deltaZ * -1;

            yield return new WaitForSeconds(waitDuration);
        }
    }
}
