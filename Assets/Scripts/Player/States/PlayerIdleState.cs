using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateController controller)
    {
        Debug.Log("[PlayerState] Enter Idle State");
        controller.player.UpdateAnimator();
        if (controller.player.animator != null)
            controller.player.animator.SetBool("isIdle", true);
        controller.player.animalSwapper.enabled = true;
        controller.move.isJumping = false;
    }

    public override void OnCollisionEnter(PlayerStateController controller) {}

    public override void Update(PlayerStateController controller)
    {
        if (Mathf.Abs(controller.move.Movement.x) > 0 || Mathf.Abs(controller.move.Movement.z) > 0) 
        {
            controller.TransitionToState(controller.walkingState);
        }     
    }
}
