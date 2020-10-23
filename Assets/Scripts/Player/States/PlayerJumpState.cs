using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateController controller)
    {
        controller.player.animator.SetBool("isJumping", true);
        Debug.Log("Jump state entered");
    }

    public override void OnCollisionEnter(PlayerStateController controller)
    {
        if (controller.move.canJump) 
        {
            if (controller.player.animator != null) 
            {
                controller.player.animator.SetBool("isJumping", false);
            }
            
            controller.TransitionToState(controller.idleState);  
        }
           
    }

    public override void Update(PlayerStateController controller)
    {

        if (controller.move.rb.velocity.y < 0)
        {
            controller.move.rb.velocity += Vector3.up * Physics.gravity.y * (controller.player.currentAnimal.jumpGravityMulti - 1) * Time.deltaTime;
        }
        else if (controller.move.rb.velocity.y > 0) 
        {
            controller.move.rb.velocity += Vector3.up * Physics.gravity.y * (controller.player.currentAnimal.jumpGravityMulti/2 - 1) * Time.deltaTime;
        }
    }
}
