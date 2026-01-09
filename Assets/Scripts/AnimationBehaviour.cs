using UnityEngine;
[RequireComponent(typeof(Animator))]

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void RunAnimation(Vector3 velocity)
    {
        Debug.Log("Heyyyyy");
        _animator.SetFloat("Velocity", velocity.magnitude);
    }
}
