using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerStateController controller)
    {
        Debug.Log("[PlayerState] Enter Walking State");
        controller.player.UpdateAnimator();
        controller.player.animator.SetBool("isIdle", false);
    }

    public override void OnCollisionEnter(PlayerStateController controller)
    {
    }

    public override void Update(PlayerStateController controller)
    {
        if (Mathf.Abs(controller.move.Movement.x) <= 0 && Mathf.Abs(controller.move.Movement.z) <= 0)
        {
            controller.TransitionToState(controller.idleState);
        }

        if (controller.move.isJumping)
        {
            controller.TransitionToState(controller.jumpState);
        }
    }
}

