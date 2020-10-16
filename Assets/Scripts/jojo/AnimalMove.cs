using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class AnimalMove : MonoBehaviour
{
    Rigidbody playerRb;
    Animator animalAnim;
    Player player;

    Vector3 movement;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        animalAnim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!player.currentAnimal.canChargeJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                playerRb.velocity = Vector3.up * player.currentAnimal.jumpForce;
            }
        }
        else
        {
            float currentCharge = player.currentAnimal.currentCharge;
            float maxCharge = player.currentAnimal.maxCharge;

            if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
            {
                player.currentAnimal.currentCharge = currentCharge > maxCharge ? 
                    maxCharge : currentCharge + Time.deltaTime * player.currentAnimal.jumpForce;
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Fire1"))
            {
                playerRb.velocity = Vector3.up * player.currentAnimal.currentCharge;
                player.currentAnimal.currentCharge  = player.currentAnimal.jumpForce;
            }
        }

        movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse X"), Input.GetAxis("Vertical"));

        //playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.deltaTime);
        playerRb.position = Vector3.MoveTowards(transform.position, playerRb.position + movement * player.currentAnimal.movementSpeed * Time.deltaTime, 1);
    }


    void OnCollisionEnter(Collision other)
    {
        // If in water check if animal can swim. If not change to trigger
        if (other.gameObject.tag == "Water")
        {
            other.collider.isTrigger = !player.currentAnimal.canSwim ? true : false;
        }
    }
}
