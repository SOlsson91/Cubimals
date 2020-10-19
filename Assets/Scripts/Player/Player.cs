using UnityEngine;

/*
 * Main player class, will add the other classes functionallity in this one.
 */

public class Player : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public SwapAnimal animalSwapper;
    [HideInInspector] public int playerNumber;

    void Start()
    {
        animalSwapper = GetComponent<SwapAnimal>();
        animalSwapper.currentAnimalNumber = 0;
        animalSwapper.ChangeAnimal(animalSwapper.currentAnimalNumber);
    }

    public void UpdateAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }
}
