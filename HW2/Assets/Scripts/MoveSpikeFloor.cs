using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikeFloor : MonoBehaviour
{
    private float deltaY = 3f;
    private float waitDuration = 3.5f;
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
            Debug.Log(transform.position);
            if ((transform.position.y >= 0) || (transform.position.y <= -3f))
                deltaY = deltaY * -1;

            yield return new WaitForSeconds(waitDuration);
        }
    }
}
