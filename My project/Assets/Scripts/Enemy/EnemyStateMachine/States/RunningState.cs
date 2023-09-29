using UnityEngine;

public class RunningState : IStateSwitcher
{
    private StateMachine _stateMachine;
    private Animator _animator;
    private AiNavigator _aiNavigator;
    private float _runningSpeed = 4f;

    public RunningState(StateMachine machine,  Animator animator, AiNavigator aiNavigator)
    {
        _stateMachine = machine;
        _animator = animator;
        _aiNavigator = aiNavigator;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
