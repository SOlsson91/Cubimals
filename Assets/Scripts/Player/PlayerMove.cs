using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Player player;

    Vector3 movement;
    bool canJump;
    bool charing = false;

    public Vector3 Movement
    {
        get { return movement; }
        set { movement = value; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    public void OnMove(Vector2 direction)
    {
        movement.x = direction.x;
        movement.z = direction.y;
    }

    public void Move()
    {
        rb.position = Vector3.MoveTowards(transform.position, rb.position + movement * player.animalSwapper.currentAnimal.movementSpeed * Time.deltaTime, 1);

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
        canJump = true;
        // If in water check if animal can swim. If not change to trigger
        if (other.gameObject.tag == "Water")
        {
            other.collider.isTrigger = !player.animalSwapper.currentAnimal.canSwim ? true : false;
        }
    }

    public void Jump()
    {
        if (!player.animalSwapper.currentAnimal.canChargeJump && canJump)
        {
            canJump = false;
            rb.velocity = Vector3.up * player.animalSwapper.currentAnimal.jumpForce;
        }
        else
        {
            if (canJump)
            {
                float currentCharge = player.animalSwapper.currentAnimal.currentCharge;
                float maxCharge = player.animalSwapper.currentAnimal.maxCharge;
                rb.velocity = Vector3.up * player.animalSwapper.currentAnimal.currentCharge;
                player.animalSwapper.currentAnimal.currentCharge  = player.animalSwapper.currentAnimal.jumpForce;

                canJump = false;
                charing = false;
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
        float currentCharge = player.animalSwapper.currentAnimal.currentCharge;
        float maxCharge = player.animalSwapper.currentAnimal.maxCharge;
        player.animalSwapper.currentAnimal.currentCharge = currentCharge > maxCharge ? 
            maxCharge : currentCharge + Time.deltaTime * player.animalSwapper.currentAnimal.jumpForce;
    }
}
