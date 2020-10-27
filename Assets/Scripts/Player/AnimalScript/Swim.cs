using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : Ability
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
        if (collision.gameObject.tag == "Water") 
        {
            animal.movementSpeed = 10;
        }
        
    }
}
