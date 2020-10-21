using UnityEngine;

/*
 * Class to handle specific animal behaviours
 */

public class Animal : MonoBehaviour
{
    [Header("General Settings")]
    public float jumpForce;
    public float movementSpeed;
    public bool canSwim;
    [Header("Charge Jump")]
    public bool canChargeJump;
    [HideInInspector] public float currentCharge;
    public float maxCharge = 10;
    [Header("Ability")]
    public Ability ability;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
