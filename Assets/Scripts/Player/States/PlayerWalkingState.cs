using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerStateController controller)
    {
        Debug.Log("Walking state entered");
        controller.player.UpdateAnimator();
        controller.player.animator.SetBool("isIdle", false);
    }

    public override void OnCollisionEnter(PlayerStateController controller)
    {
    }

    public override void Update(PlayerStateController controller)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.player.UpdateAnimator();
            controller.player.animator.SetBool("isJumping", true);
            controller.TransitionToState(controller.jumpState);
        }
        if (Mathf.Abs(controller.move.movement.x) <= 0 && Mathf.Abs(controller.move.movement.z) <= 0)
        {
            controller.TransitionToState(controller.idleState);
        }
    }
}
