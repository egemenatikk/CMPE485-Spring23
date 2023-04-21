using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGummyFloor : MonoBehaviour
{
    private float deltaY = 0.01f;
    private float waitDuration = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveUpDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            transform.position = transform.position + new Vector3(0, deltaY, 0);
            if ((transform.position.y > 0.3f) || (transform.position.y < -2.99f))
                deltaY = deltaY * -1;

            yield return new WaitForSeconds(waitDuration);
        }
    }
}
