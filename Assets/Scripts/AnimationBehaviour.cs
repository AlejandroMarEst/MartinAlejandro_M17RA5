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
}
