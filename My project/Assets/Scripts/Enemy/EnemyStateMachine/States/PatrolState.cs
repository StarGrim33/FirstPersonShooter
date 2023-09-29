using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IStateSwitcher
{
    private readonly StateMachine _machine;
    private readonly List<Transform> _movePoints;
    private readonly Transform _npcTransform;
    private Transform _lastPoint;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private int _currentPointIndex = 0;
    private float _delayTime = 2f;
    private float _time = 0;
    private float _walkSpeed = 0.6f;

    public PatrolState(List<Transform> points, Transform npcTransform, StateMachine machine, Animator animator, NavMeshAgent navMeshAgent)
    {
        _animator = animator;
        _movePoints = points;
        _npcTransform = npcTransform;
        _machine = machine;
        _navMeshAgent = navMeshAgent;
    }

    public void Enter()
    {
        _navMeshAgent.speed = _walkSpeed;
        _animator.SetFloat(Constants.Speed, _navMeshAgent.speed);
        Debug.Log("Entered to PatrolState");
    }

    public void Exit()
    {
        Debug.Log("Exit MovementState");
    }

    public void Update()
    {
        if (_movePoints.Count > 0 && _currentPointIndex < _movePoints.Count)
        {
            _lastPoint = _movePoints[_currentPointIndex];
            _navMeshAgent.destination = _lastPoint.position;

            if (Vector3.Distance(_npcTransform.position, _lastPoint.position) < 2f)
            {
                _navMeshAgent.isStopped = true;

                _time += Time.deltaTime;

                if (_time >= _delayTime)
                {
                    _currentPointIndex++;
                    _time = 0f;
                    _navMeshAgent.isStopped = false;

                    if (_currentPointIndex >= _movePoints.Count)
                    {
                        _currentPointIndex = 0;
                        _machine.SetRunningState();
                    }
                }
            }
            else
            {
                _time = 0f;
            }
        }
    }
}
