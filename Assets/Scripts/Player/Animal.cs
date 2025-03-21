﻿using UnityEngine;
using UnityEngine.UI;

/*
 * Class to handle specific animal behaviours, each animal has one and it defines the characteristics of that animal
 */

public class Animal : MonoBehaviour
{
    [Header("General Settings")]
    public float jumpForce;
    //Edited: makes the animals gravity higher to fall faster
    public float jumpGravityMulti=2.5f;
    public float movementSpeed;
    public float animalMass = 1;
    public bool canSwim;
    [Header("Charge Jump")]
    public bool canChargeJump;
    [HideInInspector] public float currentCharge;
    public float maxCharge = 10;
    [Header("Ability")]
    public Ability ability;
    [Header("Interactions")]
    public float interactDistance = 1.0f;

    public void Interact()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, interactDistance))
        {
            if (collider.CompareTag("Interactable"))
            {
                collider.GetComponent<ActivateButton>().ActivateTarget();
                return;
            }
        }
    }
}
