using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashPower = 100;
    public float cooldownValue = 1;

    private float cooldownNext = 0;

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && Time.time > cooldownNext)
        {
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * dashPower * Time.deltaTime;

            cooldownNext = Time.time + cooldownValue;

            Debug.Log("Dash");
        }
    }
}
