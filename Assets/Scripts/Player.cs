using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    [SerializeField] float mouseSensitivity = 2.5f;
    private InputSystem_Actions inputActions;
    private Vector3 _movement;
    private Vector2 _lookInput;
    private bool _jumpRequested;
    private float _yaw;
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
        if (_jumpRequested)
        {
            _mb.Jump();
            _jumpRequested = false;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
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
        throw new System.NotImplementedException();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
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

    
}
