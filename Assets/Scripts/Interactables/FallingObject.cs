using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The falling block that will fall when the Player collides with it

[RequireComponent(typeof(Rigidbody))] // The script will require a rigidbody on the object

public class FallingObject : MonoBehaviour
{
    [HideInInspector]public Vector3 defualtPosition; // Original Position for the object

    //public float fallDelay = 0.3f; // The delay in which the block wait before it falls
    public float rebuildDelay = 10; // The delay in which the block wait before it goes back to it's default position

    Rigidbody myRigidbody;

    private bool isFalling; // Regulates the state of the object

    private void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();

        myRigidbody.mass = 10;

        // Freezes most forces
        myRigidbody.isKinematic = true;
        myRigidbody.useGravity = true;
        myRigidbody.freezeRotation = true;

        defualtPosition = gameObject.transform.position; // Sets the original position

        isFalling = false; // The object starts not falling
    }

    private void Update()
    {
        if(isFalling) // If the block is falling, then make it fall
        {
            myRigidbody.isKinematic = false; // This makes it fall

            StartCoroutine(DelayFall()); // Calls the delay Coroutine
            isFalling = false; // When everything else is else finished then we're not falling anymore
        }
    }

    IEnumerator DelayFall() // The delay method
    {
        yield return new WaitForSeconds(rebuildDelay); // The delay to wait before the object rebuilds itself

        myRigidbody.isKinematic = true; // Stops the gravity impact on the object
        gameObject.transform.position = defualtPosition; // Put the object back to it's default position
    }

    private void OnCollisionEnter(Collision collision) // When collided with an object, it will check if the player is the one to collide with the object if so then the object is falling
    {
        Debug.Log("Collided with " + collision.gameObject);

        if(collision.gameObject.tag == "Player") // Checks if the player collides with the object
        {
            isFalling = true; // The object is falling
        }
    }
}
