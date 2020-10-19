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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.player.UpdateAnimator();
            controller.player.animator.SetBool("isJumping", true);
            controller.TransitionToState(controller.jumpState);
        }
        if (Mathf.Abs(controller.move.movement.x) > 0 || Mathf.Abs(controller.move.movement.z) > 0) 
        {
            controller.TransitionToState(controller.walkingState);
        }     
    }
}
