using UnityEngine;
using UnityEngine.AI;

public class RunningState : IStateSwitcher
{
    private StateMachine _stateMachine;
    private Animator _animator;
    private float _runningSpeed = 3f;
    private readonly Transform _player;
    private readonly NavMeshAgent _agent;
    private float _maxDistance = 1f;
    private Transform _npc;

    public RunningState(StateMachine machine, Animator animator, Transform npcTransform, Transform playerTransform, NavMeshAgent navMeshAgent, Transform npc)
    {
        _stateMachine = machine;
        _animator = animator;
        _agent = navMeshAgent;
        _player = playerTransform;
        _npc = npcTransform;
    }

    public void Enter()
    {
        // Воспроизвести можно звук клича или что то подобное

        _agent.speed = _runningSpeed;
        _animator.SetFloat(Constants.Speed, _agent.speed);
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _agent.destination = _player.position;

        if (Vector3.Distance(_npc.position, _player.position) < 2f)
        {
            _stateMachine.SetAttackState();
        }
    }
}
