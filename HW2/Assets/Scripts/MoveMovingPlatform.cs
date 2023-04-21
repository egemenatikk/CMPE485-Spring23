using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMovingPlatform : MonoBehaviour
{
    private float deltaZ = 0.05f;
    private float waitDuration = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            transform.position = transform.position + new Vector3(0, 0, deltaZ);
            if ((transform.position.z > 160f) || (transform.position.z < 141.5f))
                deltaZ = deltaZ * -1;

            yield return new WaitForSeconds(waitDuration);
        }
    }
}
