using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
	private CharacterController _charController;
    private AnimationBehaviour _animController;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float gravity = -2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		_charController = GetComponent<CharacterController>();
        _animController = GetComponentInChildren<AnimationBehaviour>();
    }

	// Update is called once per frame
	void FixedUpdate()
    {
    }
	public void MoveCharacter(Vector3 direction)
	{
        _charController.Move(direction * movementSpeed * Time.deltaTime);
        _animController.RunAnimation(direction);
    }
}
