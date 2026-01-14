using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    [SerializeField] float mouseSensitivity = 2.5f;
    private InputSystem_Actions inputActions;
    private Vector3 _movement;
    private float _lookX;
    private float _lookY;
    private bool _running = false;
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
    void FixedUpdate()
    {
        if (_movement != null)
        {
            _mb.MoveCharacter(new Vector3(_movement.x, 0, _movement.y), _running);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouse = context.ReadValue<Vector2>();
        _lookX += mouse.x * mouseSensitivity;
        _lookY -= mouse.y * mouseSensitivity;
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
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
