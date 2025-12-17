using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : Character, InputSystem_Actions.IPlayerActions
{
	private InputSystem_Actions inputActions;
    private Vector2 _movement;
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
	void  FixedUpdate()
    {
        _mb.MoveCharacter(new Vector3(_movement.x, 0, _movement.y));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }
}
