using UnityEngine;
/*
 * Main player class, will add the other classes functionallity in this one.
 */

public class Player : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public SwapAnimal animalSwapper;
    [HideInInspector] public int playerNumber;
    [HideInInspector] public Animal currentAnimal = null;
    [HideInInspector] public int currentAnimalNumber;
    [HideInInspector] public Checkpoint checkpoint;

    void Awake()
    {
        animalSwapper = GetComponent<SwapAnimal>();
    }

    void Start()
    {
        checkpoint = new Checkpoint(transform.position);
        currentAnimalNumber = 0;
        animalSwapper.ChangeAnimal(currentAnimalNumber);
    }

    public void UpdateAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }
}
