using UnityEngine;

// This script is keeping track of all the triggers that is placed in the array

public class SendActive : MonoBehaviour
{
    public GameObject[] triggers; // <-- Reference the triggers in here;    This array will store all the triggers this object should keep track of

    public Gate targetScript; // Reference your target Gate script here. This script should be attached the Object along with the Gate script

    private bool active;

    public void TriggerUpdate() // This is the Update but for Trigger and should be called everytime you want to check if for example a button has been pressed in the array
    {
        int count = 0; // Will store how many false triggers

        foreach(var trgs in triggers) // Goes through each trigger in the array
        {
            if(trgs != null) // Checks if the object in the current place is not null
            {
                if(!trgs.GetComponent<WeightButton>().getActive) // Checks if the current trigger is false and adds it to the count
                {
                    count++;
                }
            }

        }

        if(count == triggers.Length) // Check if all triggers in the array have been false
        {
            active = false; // Gate is not active
        }
        else
        {
            active = true; // Gate is active
        }

        targetScript.getActive = active; // Sends Active or False
    }
}
