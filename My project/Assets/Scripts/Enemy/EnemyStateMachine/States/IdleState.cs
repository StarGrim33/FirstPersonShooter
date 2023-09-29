using UnityEngine;

public class IdleState : IStateSwitcher
{
    private StateMachine _machine;
    private float _duration = 2f;
    private float _time;
    private Animator _animator;

    public IdleState(StateMachine machine, Animator animator)
    {
        _machine = machine;
        _animator = animator;
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
