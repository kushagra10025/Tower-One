using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour{
    [Header("Movement Settings")]
    public float movementSpeed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;

    [Header("Ground Check")] 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Animation Settings")] 
    public Animator animatorController;
    public string movementKey;
    public string deathKey;

    private PlayerInputActions _playerInputActions;
    private CharacterController _characterController;
    private Vector2 _movementInput;
    private Vector3 _velocity;
    private float _turnSmoothVelocity;
    private bool _isGrounded;

    private void Awake(){
        _characterController = GetComponent<CharacterController>();
        if (movementKey == null)
            movementKey = "MovementKey";
        if (deathKey == null)
            deathKey = "IsDeadKey";
        
        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable(){
        _playerInputActions.Enable();
        _playerInputActions.Player.Movement.performed += SetMovementInput;
        _playerInputActions.Player.Movement.started += SetMovementInput;
        _playerInputActions.Player.Movement.canceled += SetMovementInput;
    }

    private void OnDisable(){
        _playerInputActions.Disable();
        _playerInputActions.Player.Movement.performed -= SetMovementInput;
        _playerInputActions.Player.Movement.started -= SetMovementInput;
        _playerInputActions.Player.Movement.canceled -= SetMovementInput;
    }

    private void Start(){
    }

    public void SetMovementInput(InputAction.CallbackContext context){
        _movementInput = context.ReadValue<Vector2>();
        animatorController.SetFloat(movementKey,_movementInput.magnitude);
    }

    private void DoMovement(){
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0f){
            _velocity.y = -2f;
        }

        Vector3 t_Direction = new Vector3(_movementInput.x,0f,_movementInput.y).normalized;

        if (t_Direction.magnitude >= 0.1f){
            float t_targetAngle = Mathf.Atan2(t_Direction.x, t_Direction.z) * Mathf.Rad2Deg;
            float t_angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, t_targetAngle,
                ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,t_angle,0f);
            _characterController.Move(t_Direction * (movementSpeed * Time.deltaTime));
        }
        
        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Update(){
        DoMovement();
    }

    public void SetDeathState(bool deathState){
        animatorController.SetBool(deathKey,deathState);
    }
}