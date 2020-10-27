using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendActive : MonoBehaviour
{
    public GameObject[] triggers;
    public Gate targetScript;

    private bool active;

    public void TriggerUpdate()
    {
        int count = 0;

        foreach(var trgs in triggers)
        {
            if(!trgs.GetComponent<WeightButton>().getActive)
            {
                count++;
            }
        }

        if(count == triggers.Length)
        {
            active = false;
        }
        else
        {
            active = true;
        }

        targetScript.getActive = active;
    }
}
