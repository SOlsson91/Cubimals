using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateController controller)
    {
        Debug.Log("Jump state entered");
        
    }

    public override void OnCollisionEnter(PlayerStateController controller)
    {
        controller.TransitionToState(controller.idleState);
    }

    public override void Update(PlayerStateController controller)
    {
    }
}
