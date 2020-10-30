using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    Player player;
    CaveCam cam;

    Vector3 movement;
    bool charging = false;
    public bool isJumping = false;


    public Vector3 Movement
    {
        get
        {
            return movement;
        }
        set
        {
            movement = value;
        }
    }

    void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CaveCam>();
    }

    public void OnMove(Vector2 direction)
    {
        Debug.Log("cam val:" + cam.camera.inCave);
        movement.x = direction.x;
        movement.z = direction.y;
        if (cam.camera.inCave)
        {
            Debug.Log("Inverted controlls");
            movement.x = direction.y;
            movement.z = -direction.x;
        }
        if (cam == null)
            return;



    }

    public void Move()
    {
        if (player.currentAnimal == null) return;
        rb.position = Vector3.MoveTowards(transform.position, rb.position + movement * player.currentAnimal.movementSpeed * Time.deltaTime, 1);


        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
    void Update()
    {
        Move();
        if (charging) Charging();
    }

    void OnCollisionEnter(Collision other)
    {
        string currTag = other.gameObject.tag;

        if (other.gameObject.tag == "Water")
        {
            Debug.Log("In water");
            if (player.currentAnimal.GetComponent<Animal>() != null && player.currentAnimal.canSwim)
            {
                player.currentAnimal.GetComponent<Animal>().movementSpeed += 4;
            }
            player.currentAnimal.GetComponent<Collider>().isTrigger = !player.currentAnimal.canSwim ? true : false;
            StartCoroutine(ChangeBackWater(player));
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Water")
        {
            if (player.currentAnimal.GetComponent<Animal>() != null && player.currentAnimal.canSwim)
            {
                player.currentAnimal.GetComponent<Animal>().movementSpeed -= 4;
            }
        }
    }

    IEnumerator ChangeBackWater(Player player)
    {
        float startY = player.transform.position.y;
        yield return new WaitUntil(() => player.transform.position.y > startY);
        player.GetComponentInChildren<Collider>().isTrigger = false;
    }

    public void Jump()
    {
        if (CheckForGround())
        {
            isJumping = true;
            if (!player.currentAnimal.canChargeJump)
            {
                rb.velocity = Vector3.up * player.currentAnimal.jumpForce;
            }
            else
            {
                float currentCharge = player.currentAnimal.currentCharge;
                float maxCharge = player.currentAnimal.maxCharge;

                // Makes it so that the animal cannot jump less then its jumpForce
                if (player.currentAnimal.currentCharge < player.currentAnimal.jumpForce) player.currentAnimal.currentCharge = player.currentAnimal.jumpForce;

                rb.velocity = Vector3.up * player.currentAnimal.currentCharge;
                player.currentAnimal.currentCharge = player.currentAnimal.jumpForce;

                charging = false;
            }
        }
    }

    public void StartCharging()
    {
        if (CheckForGround()) charging = true;
    }

    void Charging()
    {
        float currentCharge = player.currentAnimal.currentCharge;
        float maxCharge = player.currentAnimal.maxCharge;
        player.currentAnimal.currentCharge = currentCharge > maxCharge ? maxCharge : currentCharge + Time.deltaTime * player.currentAnimal.jumpForce;
    }

    public bool CheckForGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    public void ChangeMass()
    {
        rb.mass = player.currentAnimal.animalMass;
    }
}
