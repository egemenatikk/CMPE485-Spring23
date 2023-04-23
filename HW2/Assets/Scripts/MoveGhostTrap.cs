using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGhostTrap : MonoBehaviour
{
    private float deltaX = -0.015f;
    private float waitDuration = 0.005f;

    void Start()
    {
        StartCoroutine(MoveLeftRight());
    }

    IEnumerator MoveLeftRight()
    {
        while (true)
        {
            transform.position = transform.position + new Vector3(deltaX, 0, 0);
            if ((transform.position.x > -3f) || (transform.position.x < -26f))
                deltaX = deltaX * -1;

            yield return new WaitForSeconds(waitDuration);
        }
    }
}
