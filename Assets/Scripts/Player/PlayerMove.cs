using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody playerRb;
    [HideInInspector] public Animator animator;
    Player player;

    public Vector3 movement;
    Vector3 inputDir;
    bool canJump;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        animator = player.animator;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        inputDir.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (inputDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputDir);
        }

        if (!player.currentAnimal.canChargeJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump || Input.GetButtonDown("Fire1"))
            {
                canJump = false;
                playerRb.velocity = Vector3.up * player.currentAnimal.jumpForce;
            }
        }
        else
        {
            float currentCharge = player.currentAnimal.currentCharge;
            float maxCharge = player.currentAnimal.maxCharge;

            if (Input.GetKey(KeyCode.Space) && canJump || Input.GetButton("Fire1"))
            {
                player.currentAnimal.currentCharge = currentCharge > maxCharge ? 
                    maxCharge : currentCharge + Time.deltaTime * player.currentAnimal.jumpForce;
            }
            if (Input.GetKeyUp(KeyCode.Space) && canJump || Input.GetButtonUp("Fire1"))
            {
                playerRb.velocity = Vector3.up * player.currentAnimal.currentCharge;
                player.currentAnimal.currentCharge  = player.currentAnimal.jumpForce;
            }
        }

        movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse X"), Input.GetAxis("Vertical"));

        playerRb.position = Vector3.MoveTowards(transform.position, playerRb.position + movement * player.currentAnimal.movementSpeed * Time.deltaTime, 1);
    }


    void OnCollisionEnter(Collision other)
    {
        canJump = true;
        // If in water check if animal can swim. If not change to trigger
        if (other.gameObject.tag == "Water")
        {
            other.collider.isTrigger = !player.currentAnimal.canSwim ? true : false;
        }
    }
}
