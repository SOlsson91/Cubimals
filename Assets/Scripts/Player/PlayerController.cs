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
    Player player;
    PlayerInput input;

    Vector2 movement;

    void Awake()
    {
        player = GetComponent<Player>();
        mover = GetComponent<PlayerMove>();
        swapper = GetComponent<SwapAnimal>();
        input = GetComponent<PlayerInput>();
        stateController = GetComponent<PlayerStateController>();
        controls = new MasterInput();
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

    public void OnAbility(InputAction.CallbackContext ctx)
    {
        if (player.currentAnimal.ability != null)
        {
            if (ctx.started)
            {
                player.currentAnimal.ability.DoAbility();
            }
        }
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
