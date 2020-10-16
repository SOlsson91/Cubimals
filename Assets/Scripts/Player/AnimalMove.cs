using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class AnimalMove : MonoBehaviour
{
    Rigidbody playerRb;
    Animator animalAnim;

    public float moveSpeed=5f;
    public float forwardSpeed;
    public Vector3 movement;


    Vector3 inputDir;

    float jumpSpeed =5f;
    bool canJump;

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
        inputDir.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //Checks if there is any current input on x/z from the player
        if (inputDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputDir);
        }

        if (Input.GetKeyDown(KeyCode.Q) && canJump || Input.GetButtonDown("Fire1") )
        {
            playerRb.velocity = Vector3.up * jumpSpeed;
            canJump = false;
        }
        
        movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse X"), Input.GetAxis("Vertical"));

        playerRb.position = Vector3.MoveTowards(transform.position, playerRb.position + movement * moveSpeed * Time.deltaTime, 1);

    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;   
    }


}
