using NUnit.Framework.Internal.Execution;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    [SerializeField] float mouseSensitivity = 2.5f;
    [SerializeField] private float interactDistance = 2.5f;
    [SerializeField] private LayerMask interactMask;
    private IInteractable _currentInteractable;
    private InputSystem_Actions inputActions;
    private Vector3 _movement;
    private Vector2 _lookInput;
    private bool _jumpRequested;
    private float _yaw;
    private bool _dancing = false;
    private bool _running = false;
    private bool _aiming = false;
    private void Awake()
    {
        base.Awake();
        inputActions = new InputSystem_Actions();
		inputActions.Player.SetCallbacks(this);
    }
	private void OnEnable()
	{
		inputActions.Enable();
	}
	private void OnDisable()
	{
		inputActions.Disable();
	}
    void Update()
    {
        _yaw += _lookInput.x * mouseSensitivity;
        _mb.RotateCharacter(Quaternion.Euler(0f, _yaw, 0f));
        _mb.MoveCharacter(new Vector3(_movement.x, 0f, _movement.y), _running);
        _mb.Aim(_aiming);
        CheckInteractable();
        if (_jumpRequested)
        {
            _mb.Jump();
            _jumpRequested = false;
        }
        _mb.Dance(_dancing);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
        _dancing = false;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _dancing = false;
            _mb.Attack();
        }
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        _dancing = false;
        if (context.performed)
        {
            _aiming = true;
        }
        else if (context.canceled)
        {
            _aiming = false;
        }
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _dancing = true;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        _dancing = false;
        if (context.performed)
        {
            _jumpRequested = true;
        }
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _running = true;
        }
        else if (context.canceled)
        {
            _running = false;
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _currentInteractable?.Interact(this);
        }
    }
    void CheckInteractable()
    {
        _currentInteractable = null;
        Vector3 origin = transform.position + Vector3.up * 1.5f;
        Vector3 dir = transform.forward;
        Debug.DrawRay(origin, dir * interactDistance, Color.red);
        if (Physics.Raycast(origin, dir, out RaycastHit hit, interactDistance, interactMask))
        {
            var interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                _currentInteractable = interactable;
                Debug.Log("Interactable detected: " + hit.collider.name);
            }
        }
    }
}
