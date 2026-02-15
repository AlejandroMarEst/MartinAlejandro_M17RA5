using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
	private CharacterController _charController;
    private AnimationBehaviour _animController;
    private Vector3 velocity;
    private Vector3 _horizontalMove;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float gravity = -10f;
    [SerializeField] private float turnSpeed = -2;
    void Awake()
    {
		_charController = GetComponent<CharacterController>();
        _animController = GetComponentInChildren<AnimationBehaviour>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (_charController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
        velocity.y += gravity * Time.deltaTime;
        Vector3 finalMove = _horizontalMove * movementSpeed + velocity;
        _charController.Move(finalMove * Time.deltaTime);
        if (!_charController.isGrounded)
        {
            _animController.Fall(velocity.y);
        }
        else
        {
            _animController.Grounded();
        }
    }
    public void MoveCharacter(Vector3 direction, bool running)
    {
        _horizontalMove = direction.x * transform.right + direction.z * transform.forward;
        _horizontalMove.y = 0;
        _animController.MoveAnimation(direction);
        _animController.RunAnimation(running);
    }
    public void RotateCharacter(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
    public void Jump()
    {
        if (_charController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            _animController.Jump();
        }
    }
    public void Aim(bool aiming)
    {
        _animController.Aiming(aiming);
    }
    public void Attack()
    {
        _animController.Attack();
    }
    public void Dance(bool dance)
    {
        _animController.Dance(dance);
    }
}
