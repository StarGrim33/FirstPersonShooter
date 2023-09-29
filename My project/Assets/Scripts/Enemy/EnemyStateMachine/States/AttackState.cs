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

    public AttackState(StateMachine stateMachine, Animator animator, PlayerHealth target, Transform player, Transform npc)
    {
        _stateMachine = stateMachine;
        _animator = animator;
        _target = target;
        _player = player;
        _npc = npc;
    }

    public void Enter()
    {
        _animator.SetBool(Constants.IsAttacking, true);
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
        if(Vector3.Distance(_player.position, _npc.position) < _maxDistance)
        {
            _target.TakeDamage(_damage);
            _npc.LookAt(_player.position);
        }
        else
        {
            _animator.SetBool(Constants.IsAttacking, false);
            _stateMachine.SetRunningState();
        }
    }
}
