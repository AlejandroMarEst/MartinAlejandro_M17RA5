using UnityEngine;
[RequireComponent(typeof(Animator))]

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void MoveAnimation(Vector3 velocity)
    {
        _animator.SetFloat("Velocity", velocity.magnitude);
    }
    public void RunAnimation(bool running)
    {
        _animator.SetBool("Running", running);
    }
    public void Jump() {
        _animator.SetBool("Jumping", true);
    }
    public void Fall(float verticalVelocity)
    {
        _animator.SetFloat("VerticalVelocity", verticalVelocity);
        _animator.SetBool("Grounded", false);
    }
    public void Grounded()
    {
        _animator.SetBool("Grounded", true);
    }
    public void Aiming(bool aim)
    {
        _animator.SetBool("Aiming", aim);
    }
    public void Attack() {
        _animator.SetTrigger("Punch");
    }
    public void Dance(bool dance)
    {
        _animator.SetBool("Dancing", dance);
    }
}
