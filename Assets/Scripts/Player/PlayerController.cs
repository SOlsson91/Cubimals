using UnityEngine;
using UnityEngine.InputSystem;
/*
 * Class to handle the input from Unitys new input system.
 */

public class PlayerController : MonoBehaviour
{
    MasterInput controls;
    PlayerMove mover;
    SwapAnimal swapper;
    PlayerStateController stateController;

    Vector2 movement;

    void Awake()
    {
        controls = new MasterInput();
        stateController = GetComponent<PlayerStateController>();
        mover = GetComponent<PlayerMove>();
        swapper = GetComponent<SwapAnimal>();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    // Wrapper functions to map input to functions
    public void OnMove(InputAction.CallbackContext ctx) => mover.OnMove(ctx.ReadValue<Vector2>());
    public void OnSwap(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            swapper.Swap();
    }
    
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            mover.StartCharging();
        }
        if (ctx.canceled)
        {
            stateController.player.UpdateAnimator();
            stateController.player.animator.SetBool("isJumping", true);
            stateController.TransitionToState(stateController.jumpState);
            mover.Jump();
            
        }
    }
}
