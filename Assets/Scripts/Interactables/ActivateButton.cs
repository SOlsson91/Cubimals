using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public GameObject player;
    public GameObject target;

    public float interactiveRadius = 1;

    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= interactiveRadius && Input.GetKeyDown(KeyCode.E) && isActive == false)
        {
            isActive = true;
        }
        else if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= interactiveRadius && Input.GetKeyDown(KeyCode.E))
        {
            isActive = false;
        }

        target.SetActive(isActive);
    }
}
