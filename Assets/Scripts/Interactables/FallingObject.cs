using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FallingObject : MonoBehaviour
{
    [HideInInspector]public Vector3 defualtPosition;

    public float fallDelay = 0.3f;
    public float rebuildDelay = 10;

    Rigidbody myRigidbody;

    private bool isFalling;

    private void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();

        myRigidbody.mass = 10;

        myRigidbody.isKinematic = true;
        myRigidbody.useGravity = true;
        myRigidbody.freezeRotation = true;

        defualtPosition = gameObject.transform.position;

        isFalling = false;
    }

    private void Update()
    {
        if(isFalling)
        {
            StartCoroutine(DelayFall());
            isFalling = false;
        }
    }

    IEnumerator DelayFall()
    {
        yield return new WaitForSeconds(fallDelay);

        myRigidbody.isKinematic = false;

        yield return new WaitForSeconds(rebuildDelay);

        myRigidbody.isKinematic = true;
        gameObject.transform.position = defualtPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject);

        if(collision.gameObject.tag == "Player")
        {
            isFalling = true;
        }
    }
}
