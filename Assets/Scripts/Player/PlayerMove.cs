using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    Player player;

    Vector3 movement;
    [HideInInspector] public bool canJump;
    bool charing = false;

    float jumpAnimTimer;

    public Vector3 Movement
    {
        get { return movement; }
        set { movement = value; }
    }

    void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(Vector2 direction)
    {
        movement.x = direction.x;
        movement.z = direction.y;
    }

    public void Move()
    {
        if (player.currentAnimal == null)
            return;
        rb.position = Vector3.MoveTowards(transform.position, rb.position + movement * player.currentAnimal.movementSpeed * Time.deltaTime, 1);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
    void Update()
    {
        Move();
        if (charing)
            Charging();
    }


    void OnCollisionEnter(Collision other)
    {
        string currTag= other.gameObject.tag;

        if (other.gameObject.tag == "Water")
        {
            other.collider.isTrigger = !player.currentAnimal.canSwim ? true : false;
        }

        //use velocity margin .5 since the animation velocity is between 0 -.5
        if (other.gameObject.tag == "Ground"&&rb.velocity.y <= .5)
        {
            canJump = true;
        }
    }

    public void Jump()
    {
        if (!player.currentAnimal.canChargeJump && canJump)
        {
            canJump = false;
            player.UpdateAnimator();
            player.animator.SetBool("isJumping", true);
            rb.velocity = Vector3.up * player.currentAnimal.jumpForce;

            //jumpAnimTimer = jumpAnimTimer > .7f ?
            //    .7f : jumpAnimTimer;

            player.animator.SetFloat("Speed", 2);

            //jumpAnimTimer = 0;
        }
        else
        {
            if (canJump)
            {
                float currentCharge = player.currentAnimal.currentCharge;
                float maxCharge = player.currentAnimal.maxCharge;
                rb.velocity = Vector3.up * player.currentAnimal.currentCharge;
                player.currentAnimal.currentCharge  = player.currentAnimal.jumpForce;

                canJump = false;
                charing = false;

                //jumpAnimTimer = jumpAnimTimer > .7f ?
                //.7f : jumpAnimTimer;

                player.animator.SetFloat("Speed", 1);

                ///jumpAnimTimer =0;

                
            }
        }
    }
    public void StartCharging()
    {
        if (canJump)
            charing = true;
    }

    void Charging()
    {
        jumpAnimTimer += Time.deltaTime;

        float currentCharge = player.currentAnimal.currentCharge;
        float maxCharge = player.currentAnimal.maxCharge;
        player.currentAnimal.currentCharge = currentCharge > maxCharge ? 
            maxCharge : currentCharge + Time.deltaTime * player.currentAnimal.jumpForce;
    }
}
