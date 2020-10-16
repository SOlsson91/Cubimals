using UnityEngine;

public class AnimWalkingState : AnimBaseState
{
    public override void EnterState(AnimStateCtrl animCtrl)
    {
        Debug.Log("Walking state entered");
        animCtrl.animalAnim.SetBool("isIdle", false);
    }

    public override void OnCollisionEnter(AnimStateCtrl animCtrl)
    {
        
    }

    public override void Update(AnimStateCtrl animCtrl)
    {
        if (Mathf.Abs(animCtrl.animalMove.movement.x) <= 0 && Mathf.Abs(animCtrl.animalMove.movement.z) <= 0)
        {
            animCtrl.TransitionToState(animCtrl.idleState);
        }
    }
}
