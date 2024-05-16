using UnityEngine;

public class TargetReachedTransition : Transition
{
    private Survivor _survivor;

    private void Start()
    {
        _survivor = GetComponent<Survivor>();
    }

    protected override void ChangeState()
    {
        if (Vector3.Distance(_survivor.Target.transform.position, transform.position) <= _survivor.StopDistance)
        {
            NeedTransit = true;
        }
    }
}
