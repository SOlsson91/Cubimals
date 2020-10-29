using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float travelDistance = 1;
    public float moveSpeed = 1;

    public bool isItAGate;

    private Vector3 defaultPosition;

    private bool isActive;

    public bool getActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    private void Start()
    {
        defaultPosition = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
            if(travelDistance > 0) // UP
            {
                if(isActive && gameObject.transform.position.y < defaultPosition.y + travelDistance)
                {
                    gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else if(gameObject.transform.position.y > defaultPosition.y)
                {
                    gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else
                {
                    gameObject.transform.position = defaultPosition;
                }
            }
            else if(travelDistance < 0) // DOWN
            {
                if(isActive && gameObject.transform.position.y > defaultPosition.y + travelDistance)
                {
                    gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else if(gameObject.transform.position.y < defaultPosition.y)
                {
                    gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else
                {
                    gameObject.transform.position = defaultPosition;
                }
            }
            else
            {
                Debug.LogError("Target Destination set to 0");
            }
        }

    }


    /*private void FixedUpdate()
    {
        if(isActive && gameObject.transform.position.y != targetDestination.y && gameObject.transform.position.y > targetDestination.y)
        {
            gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
        }
        else if(gameObject.transform.position != defaultPosition)
        {
            gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        }
    }*/
