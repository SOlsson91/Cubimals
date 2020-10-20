using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushables : MonoBehaviour
{
    private void Awake()
    {
        foreach(GameObject push in GameObject.FindGameObjectsWithTag("Pushable"))
        {
            push.AddComponent<Rigidbody>();
            push.GetComponent<Rigidbody>().mass=100;
            push.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
