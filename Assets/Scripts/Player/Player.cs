using UnityEngine;

/*
 * Main player class, will add the other classes functionallity in this one.
 */

public class Player : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public SwapAnimal animalSwapper;

    void Start()
    {
        animalSwapper = GetComponent<SwapAnimal>();
        animalSwapper.ChangeAnimal(0);
    }

    public void UpdateAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }
}
