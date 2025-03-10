﻿using UnityEngine;
using UnityEngine.InputSystem;
/*
 * Class to handle the input from Unitys new input system. So pretty much
 * all input is handled or called from here. 
 */

public class PlayerController : MonoBehaviour
{
    MasterInput controls;
    PlayerMove mover;
    SwapAnimal swapper;
    Player player;
    PlayerInput input;

    void Awake()
    {
        player = GetComponent<Player>();
        mover = GetComponent<PlayerMove>();
        swapper = GetComponent<SwapAnimal>();
        input = GetComponent<PlayerInput>();
        controls = new MasterInput();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    // Wrapper functions to map input to functions
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!GameManager.Instance.isPaused)
        {
            mover.OnMove(ctx.ReadValue<Vector2>());
        }
    }

    public void OnSwap(InputAction.CallbackContext ctx)
    {
        if (!GameManager.Instance.isPaused)
        {
            if (ctx.started && mover.Movement == Vector3.zero)
                swapper.Swap();
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!GameManager.Instance.isPaused)
        {
            if (ctx.started)
            {
                Debug.Log("Interact called");
                player.currentAnimal.Interact();
            }
        }
    }

    public void OnAbility(InputAction.CallbackContext ctx)
    {
        if (!GameManager.Instance.isPaused)
        {
            if (player.currentAnimal.ability != null)
            {
                if (ctx.started)
                    player.currentAnimal.ability.DoAbility();
            }
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!GameManager.Instance.isPaused)
        {
            if (ctx.started)
            {
                mover.StartCharging();
            }
            if (ctx.canceled)
            {
                mover.Jump();
            }
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Time.timeScale = GameManager.Instance.isPaused ? 1 : 0;
            GameManager.Instance.isPaused = !GameManager.Instance.isPaused;
            EventManager.Instance.Pause();
        }
    }
}
