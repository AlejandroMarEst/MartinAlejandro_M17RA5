using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
	private CharacterController _charController;
    private AnimationController _animController;
    private Vector3 velocity;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float gravity = -2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		_charController = GetComponent<CharacterController>();
        _animController = GetComponent<AnimationController>();
	}

	// Update is called once per frame
	void FixedUpdate()
    {
    }
	public void MoveCharacter(Vector3 direction)
	{
		Vector3 movement = new Vector3(direction.x, 0, direction.z);
        _charController.Move(movement * movementSpeed * Time.deltaTime);
        _animController.RunAnimation(direction);
    }
}
