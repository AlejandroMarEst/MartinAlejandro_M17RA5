using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
	private CharacterController _charController;
    private AnimationBehaviour _animController;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float gravity = -2;
    [SerializeField] private float turnSpeed = -2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		_charController = GetComponent<CharacterController>();
        _animController = GetComponentInChildren<AnimationBehaviour>();
        Cursor.lockState = CursorLockMode.Locked;
    }
	public void MoveCharacter(Vector3 direction, bool running)
	{
        Vector3 playerMovement = direction.x * transform.right + direction.z * transform.forward;
        if (playerMovement.sqrMagnitude > 0.001 && direction.z > -0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(playerMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }
        _charController.Move(playerMovement * movementSpeed * Time.deltaTime);
        _animController.MoveAnimation(direction);
        _animController.RunAnimation(running);
    }
    public void RotateCharacter(Quaternion rotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
}
