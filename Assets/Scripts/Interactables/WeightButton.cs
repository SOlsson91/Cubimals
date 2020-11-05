using UnityEngine;

// The WeightButton pushes down the acting button and sends true or false to the SendActive script
// The design of this is a bit redundant and would need a rework

public class WeightButton : MonoBehaviour
{
    public GameObject target;

    [SerializeField] private GameObject pressurePlate = null; // This object will be pushed down as the acting button

    private Vector3 defualtPosition; // Original Position for the acting button
    private bool isPressured; // Will regulate in which state the button is and will also be the one to regulate what should be sent to the target

    public bool stonePuzzle = false; //Can be removed later, just to help quikc fix;    This is an exception for a certain button

    // -- Accessors --

    public bool getActive
    {
        get { return isPressured; }
    }

    // -- Methods --

    private void Start()
    {
        isPressured = false; // Object starts as unpressed
        defualtPosition = pressurePlate.transform.position; // Sets the original position
    }

    private void FixedUpdate()
    {
        if(pressurePlate != null) // Checks if there is a object
        {
            if(isPressured && pressurePlate.transform.position.y > defualtPosition.y - 0.3f) // Is there something standing on the button and not at it's destination, go DOWN
            {
                pressurePlate.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else if(pressurePlate.transform.position.y < defualtPosition.y) // If it's not in at default position go UP toawrds it
            {
                pressurePlate.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else // Incase the button happen to be out of place this will put it in place
            {
                pressurePlate.transform.position = defualtPosition;
            }
        }
        else
        {
            Debug.LogError("Not assigned a GameObject to acting button");
        }
    }

    private void OnTriggerEnter(Collider other) // Checks if an object Enters the collider then the button should be pressed
    {
        isPressured = true;

        if (stonePuzzle&&other.gameObject.tag=="Pushable") //Needs to be reworked, just a quick solution;    This is the exception, will check if the object is pushable then set target to true
        {
            target.SetActive(true);
        }

        if (target.GetComponent<SendActive>() != null) // Checks if there is a target SendActive script
        {
            target.GetComponent<SendActive>().TriggerUpdate(); // Update the TriggerUpdate() method in the SendActive script
        }
    }

    private void OnTriggerExit(Collider other) // Checks if an object Exits the collider then the button should be unpressed
    {
        isPressured = false;
        if (target.GetComponent<SendActive>())
        {
            target.GetComponent<SendActive>().TriggerUpdate(); // Update the TriggerUpdate() method in the SendActive script
        }
    }
}
