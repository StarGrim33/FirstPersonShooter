using UnityEngine;

public class IdleState : IStateSwitcher
{
    private StateMachine _machine;
    private float _duration = 2f;
    private float _time;

    public IdleState(StateMachine machine)
    {
        _machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered to IdleState");
    }

    public void Exit()
    {
        Debug.Log("Exit from IdleState");
    }

    public void Update()
    {
        _time += Time.deltaTime;

        if (_time > _duration)
            _machine.SetPatrolState();
    }
}
