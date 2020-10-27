using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Vector3 targetDestination;

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
        if(isActive && gameObject.transform.position.y != targetDestination.y && gameObject.transform.position.y > targetDestination.y)
        {
            gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
        }
        else if(gameObject.transform.position != defaultPosition)
        {
            gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        }
    }
}
