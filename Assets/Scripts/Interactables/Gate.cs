using UnityEngine;

// This script is supposed to be attached to the Object acting as the Gate along with the SendActive script

public class Gate : MonoBehaviour
{
    public float travelDistance = 1; // The distance the Gate is supposed to travel in one axis
    public float moveSpeed = 1; // How fast the Gate is supposed to travel

    private Vector3 defaultPosition; // Original Position of the Gate

    private bool isActive;

    // -- Accessors --

    public bool getActive 
    {
        get { return isActive; }
        set { isActive = value; }
    }

    // -- Methods --

    private void Start()
    {
        defaultPosition = gameObject.transform.position; // Sets the original position
    }

    private void FixedUpdate()
    {
            if(travelDistance > 0) // Checks if the Gate is supposed to go UP
            {
                if(isActive && gameObject.transform.position.y < defaultPosition.y + travelDistance) // Is the Gate not at it's destination then go UP
            {
                    gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else if(gameObject.transform.position.y > defaultPosition.y) // Is the Gate not active then go back to the defualt position
                {
                    gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else // Puts the Gate in it's original position if the position is a bit off
                {
                    gameObject.transform.position = defaultPosition;
                }
            }
            else if(travelDistance < 0) // Checks if the Gate is supposed to go DOWN
        {
                if(isActive && gameObject.transform.position.y > defaultPosition.y + travelDistance) // Is the Gate not at it's destination then go DOWN
            {
                    gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else if(gameObject.transform.position.y < defaultPosition.y) // Is the Gate not active then go back to the defualt position
            {
                    gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
                }
                else // Puts the Gate in it's original position if the position is a bit off
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
