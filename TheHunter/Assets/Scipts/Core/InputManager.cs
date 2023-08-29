using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerShoot shoot;
    private PLayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        shoot = GetComponent<PlayerShoot>();
        motor = GetComponent<PLayerMotor>();
        look = GetComponent<PlayerLook>();
    }
    void FixedUpdate()
    {
        ActionMove();
        ActionJump();
        ActionShoot();
    }
    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    public void OnEnable()
    {
        onFoot.Enable();
    }

    public void OnDisable()
    {
        onFoot.Disable();
    }

    private void ActionMove()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void ActionJump()
    {
        //onFoot.Jump.performed += ctx => motor.Jump();
        if (onFoot.Jump.inProgress)
        {
            motor.Jump();
        }
    }

    private void ActionShoot()
    {
        if (onFoot.Shoot.inProgress)
        {
            shoot.ProcessShoot();
        }
    }
}
