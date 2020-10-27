using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Animal animal;

    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponent<Animal>();
        playerRigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void SwimBuff() 
    {
        Debug.Log("Swimming");
        animal.movementSpeed = 10;
    }
}
