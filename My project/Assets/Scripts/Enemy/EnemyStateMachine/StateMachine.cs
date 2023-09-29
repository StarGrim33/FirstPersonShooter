using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints = new List<Transform>();
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerHealth _playerHelth;
    private Dictionary<Type, IStateSwitcher> _states;
    private IStateSwitcher _currentState;
    private Animator _animator;
    private NavMeshAgent _agent;
    private ZombieHealth _health;
    private Transform _npc;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<ZombieHealth>();
        _npc = transform;
    }

    private void Start()
    {
        Init();
        SetBehaviourByDefault();
    }

    private void Update()
    {
        if (_health.IsAlive)
            _currentState?.Update();
    }

    private void Init()
    {
        _states = new Dictionary<Type, IStateSwitcher>
        {
            [typeof(IdleState)] = new IdleState(this),
            [typeof(PatrolState)] = new PatrolState(_patrolPoints, _npc, this, _animator, _agent),
            [typeof(RunningState)] = new RunningState(this, _animator, _npc, _player, _agent, _npc),
            [typeof(AttackState)] = new AttackState(this, _animator, _playerHelth, _player, _npc)
        };
    }

    private void SetBehaviour(IStateSwitcher state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void SetBehaviourByDefault()
    {
        var behaviourByDefault = GetBehaviour<IdleState>();
        SetBehaviour(behaviourByDefault);
    }

    private IStateSwitcher GetBehaviour<T>() where T : IStateSwitcher
    {
        var type = typeof(T);
        return _states[type];
    }

    public void SetIdleState()
    {
        var state = GetBehaviour<IdleState>();
        SetBehaviour(state);
    }

    public void SetPatrolState()
    {
        var state = GetBehaviour<PatrolState>();
        SetBehaviour(state);
    }

    public void SetRunningState()
    {
        var state = GetBehaviour<RunningState>();
        SetBehaviour(state);
    }

    public void SetAttackState()
    {
        var state = GetBehaviour<AttackState>();
        SetBehaviour(state);
    }
}
