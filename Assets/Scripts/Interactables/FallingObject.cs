using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FallingObject : MonoBehaviour
{
    Rigidbody myRigidbody;

    private bool isFalling;
    private float timer;

    private void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();

        myRigidbody.mass = 10;

        myRigidbody.isKinematic = true;
        myRigidbody.useGravity = true;
        myRigidbody.freezeRotation = true;

        isFalling = false;
        timer = 4;
    }

    private void Update()
    {
        if(isFalling)
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                DestroyObject();
            }
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject);

        if(collision.gameObject.tag == "Player")
        {
            myRigidbody.isKinematic = false;
            isFalling = true;
        }
    }
}
