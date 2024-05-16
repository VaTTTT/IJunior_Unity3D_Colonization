using UnityEngine;

public class IdleState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool("IsMoving_b", false);
    }
}
