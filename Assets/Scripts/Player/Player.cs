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

    void Start()
    {
        animalSwapper = GetComponent<SwapAnimal>();
        currentAnimalNumber = 0;
        animalSwapper.ChangeAnimal(currentAnimalNumber);
    }

    public void UpdateAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }
}
