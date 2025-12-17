using UnityEngine;
[RequireComponent(typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void RunAnimation(Vector3 velocity)
    {
        _animator.SetFloat("Velocity", velocity.magnitude);
    }
}
