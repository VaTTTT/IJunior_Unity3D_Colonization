using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private Survivor _survivor;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _survivor = GetComponent<Survivor>();
    }

    private void OnEnable()
    {
        _animator.SetBool("IsMoving_b", true);
    }

    private void OnDisable()
    {
        _animator.SetBool("IsMoving_b", false);
    }

    private void Update()
    {
        if (_survivor.Target != null)
        {
            transform.LookAt(_survivor.Target.transform.position);
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }
    }
}