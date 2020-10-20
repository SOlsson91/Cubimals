using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateController controller)
    {
        Debug.Log("Entering idle state");
        controller.player.UpdateAnimator();
        controller.player.animator.SetBool("isIdle", true);
        controller.player.animalSwapper.enabled = true;
    }

    public override void OnCollisionEnter(PlayerStateController controller)
    {
    }

    public override void Update(PlayerStateController controller)
    {
        if (Mathf.Abs(controller.move.Movement.x) > 0 || Mathf.Abs(controller.move.Movement.z) > 0) 
        {
            controller.TransitionToState(controller.walkingState);
        }     
    }
}
