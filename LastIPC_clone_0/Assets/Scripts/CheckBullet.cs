using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBullet : MonoBehaviour
{
    public float lifetime = 5f;       

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
       /transform.Translate(Vector3.forward * 10f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(collision.gameObject);
        }

        //Destroy(gameObject);
    }
}
