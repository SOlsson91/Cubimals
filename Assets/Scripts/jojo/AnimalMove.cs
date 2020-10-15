using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class AnimalMove : MonoBehaviour
{
    Rigidbody playerRb;
    Animator animalAnim;

    float moveSpeed=5f;
    float jumpSpeed =5f;
    Vector3 movement;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        animalAnim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("Fire1")){ playerRb.velocity = Vector3.up*jumpSpeed;}
        movement.Set(Input.GetAxis("Horizontal"),Input.GetAxis("Mouse X"), Input.GetAxis("Vertical"));

        //playerRb.MovePosition(playerRb.position +movement*moveSpeed*Time.deltaTime);
        playerRb.position = Vector3.MoveTowards(transform.position, playerRb.position + movement*moveSpeed*Time.deltaTime,1);
    }


}
