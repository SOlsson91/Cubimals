/*
 * Abstract base class for the player controller
 */

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateController controller);
    public abstract void Update(PlayerStateController controller);
    public abstract void OnCollisionEnter(PlayerStateController controller);
}

