using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    public GameObject target;

    [SerializeField] private GameObject pressurePlate;

    private Vector3 defualtPosition;

    private bool isPressured;

    private void Start()
    {
        isPressured = false;
        defualtPosition = pressurePlate.transform.position;
    }

    private void FixedUpdate()
    {
        if(pressurePlate != null)
        {
            if(isPressured && pressurePlate.transform.position.y > defualtPosition.y - 0.3f)
            {
                pressurePlate.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else if(pressurePlate.transform.position.y < defualtPosition.y)
            {
                pressurePlate.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else
            {
                pressurePlate.transform.position = defualtPosition;
            }
        }
        else
        {
            Debug.LogError("URE: Not assigned a GameObject to target");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isPressured = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPressured = false;
    }

    /*private Vector3 defualtPosition;

    private bool isPressed;
    private void Start()
    {
        defualtPosition = gameObject.transform.position;
        isPressed = false;
    }

    private void FixedUpdate()
    {
        if(isPressed)
        {
            gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
        }
        else if(gameObject.transform.position.y < defualtPosition.y)
        {
            gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position = defualtPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            Debug.Log("Button Triggered");
            isPressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isPressed = false;
    }*/
}
