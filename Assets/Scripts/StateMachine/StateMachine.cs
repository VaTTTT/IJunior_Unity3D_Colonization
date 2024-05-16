using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        ResetStates(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void ResetStates(State startState)
    { 
        _currentState = startState;

        if (_currentState != null) 
        {
            _currentState.Enter();
        }
    }

    public void Transit(State nextState)
    {
        if (_currentState != null)
        { 
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        { 
            _currentState.Enter();
        }
    }
}
