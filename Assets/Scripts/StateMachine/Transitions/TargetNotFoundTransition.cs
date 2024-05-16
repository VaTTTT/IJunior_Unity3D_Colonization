public class TargetNotFoundTransition : Transition
{
    private Survivor _survivor;

    private void Start()
    {
        _survivor = GetComponent<Survivor>();
    }

    protected override void ChangeState()
    {
        if (_survivor.Target == null)
        {
            NeedTransit = true;
        }
    }
}