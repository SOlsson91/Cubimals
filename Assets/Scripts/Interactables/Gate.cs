using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject[] triggerObjects;

    public Vector3 targetDestination;

    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = gameObject.transform.position;
    }

    private void Update()
    {
        foreach(var trgs in triggerObjects)
        {
            //trgs.GetComponent<WeightButton>()
        }
    }

    private void FixedUpdate()
    {
        
    }
}
