using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Player player;
    Vector3 inputDir;

    [HideInInspector]public Vector3 movement;
    [HideInInspector]public bool canJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        inputDir.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Jumping();
        movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse X"), Input.GetAxis("Vertical"));

        rb.position = Vector3.MoveTowards(transform.position, rb.position + movement * player.animalSwapper.currentAnimal.movementSpeed * Time.deltaTime, 1);
    }


    void OnCollisionEnter(Collision other)
    {
        canJump = true;
        // If in water check if animal can swim. If not change to trigger
        if (other.gameObject.tag == "Water")
        {
            other.collider.isTrigger = !player.animalSwapper.currentAnimal.canSwim ? true : false;
        }
    }

    void Jumping()
    {
        if (inputDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputDir);
        }

        if (!player.animalSwapper.currentAnimal.canChargeJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump || Input.GetButtonDown("Fire1"))
            {
                canJump = false;
                rb.velocity = Vector3.up * player.animalSwapper.currentAnimal.jumpForce;
            }
        }
        else
        {
            float currentCharge = player.animalSwapper.currentAnimal.currentCharge;
            float maxCharge = player.animalSwapper.currentAnimal.maxCharge;

            if (Input.GetKey(KeyCode.Space) && canJump || Input.GetButton("Fire1"))
            {
                player.animalSwapper.currentAnimal.currentCharge = currentCharge > maxCharge ? 
                    maxCharge : currentCharge + Time.deltaTime * player.animalSwapper.currentAnimal.jumpForce;
            }
            if (Input.GetKeyUp(KeyCode.Space) && canJump || Input.GetButtonUp("Fire1"))
            {
                canJump = false;
                rb.velocity = Vector3.up * player.animalSwapper.currentAnimal.currentCharge;
                player.animalSwapper.currentAnimal.currentCharge  = player.animalSwapper.currentAnimal.jumpForce;
            }
        }
    }
}
