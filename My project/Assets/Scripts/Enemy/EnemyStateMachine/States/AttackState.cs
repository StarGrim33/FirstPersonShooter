using UnityEngine;

public class AttackState : IStateSwitcher
{
    private StateMachine _stateMachine;
    private Animator _animator;
    private readonly Transform _player;
    private float _maxDistance = 2f;
    private Transform _npc;
    private PlayerHealth _target;
    private int _damage = 25;
    private Quaternion _initialRotation;
    private float _attackRate = 2.9f;
    private float _time = 0f;

    public AttackState(StateMachine stateMachine, Animator animator, PlayerHealth target, Transform player, Transform npc)
    {
        _stateMachine = stateMachine;
        _animator = animator;
        _target = target;
        _player = player;
        _npc = npc;
        _initialRotation = _npc.transform.rotation;
    }

    public void Enter()
    {
        _animator.SetBool(Constants.IsAttacking, true);
        _time = 2.5f;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        Attack();
    }

    private void Attack()
    {
        _time += Time.deltaTime;

        if (_time > _attackRate)
        {

            if (Vector3.Distance(_player.position, _npc.position) < _maxDistance)
            {
                _target.TakeDamage(_damage);
                _npc.LookAt(_player.position);
                _npc.rotation = Quaternion.Euler(_initialRotation.eulerAngles.x, _npc.rotation.eulerAngles.y, _initialRotation.eulerAngles.z);
            }
            else
            {
                _animator.SetBool(Constants.IsAttacking, false);
                _stateMachine.SetRunningState();
            }

            _time = 0;
        }
    }
}
