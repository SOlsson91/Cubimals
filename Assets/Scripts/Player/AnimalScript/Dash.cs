using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 1000;
    public float dashTime = 0.2f;
    public float cooldownValue = 1;

    private float dashNext = 0;
    private float cooldownNext = 0;

    private bool dashing;

    private void Start()
    {
        dashing = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time > cooldownNext)
        {
            Debug.Log("Dash");

            dashing = true;
            dashNext = dashTime;

            cooldownNext = Time.time + cooldownValue;
        }
        else if(dashNext <= 0 && dashing == true)
        {
            dashing = false;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if(dashing == true)
        {
            dashNext -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (dashing == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * dashSpeed * Time.deltaTime;
        }
    }
}
