using UnityEngine;

/*
 * Class to handle specific animal behaviours
 */

public class Animal : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed;
    public bool canSwim;
    [Header("Charge Jump")]
    public bool canChargeJump;
    [HideInInspector] public float currentCharge;
    public float maxCharge = 10;
    public Ability ability;
}
