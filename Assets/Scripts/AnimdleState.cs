using UnityEngine;

public class AnimdleState : AnimBaseState
{
    public override void EnterState(AnimStateCtrl animCtrl)
    {
        Debug.Log("Entering idle state");
        animCtrl.animalAnim.SetBool("isIdle", true);
    }

    public override void OnCollisionEnter(AnimStateCtrl animCtrl)
    {
        
    }

    public override void Update(AnimStateCtrl animCtrl)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animCtrl.TransitionToState(animCtrl.jumpState);     
        }
        if (Mathf.Abs(animCtrl.animalMove.movement.x) > 0 || Mathf.Abs(animCtrl.animalMove.movement.z) > 0) 
        {
            animCtrl.TransitionToState(animCtrl.walkingState);
        }     
    }
}
