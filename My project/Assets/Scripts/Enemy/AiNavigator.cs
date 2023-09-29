using UnityEngine;
using UnityEngine.AI;

public class AiNavigator : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private NavMeshAgent _ai;
    private Animator _animator;
    private float _maxDistance = 1f;
    private Timer _timer;
    private float _maxTime = 0.5f;

    private void Awake()
    {
        _timer = new();
        _ai = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _timer.Time -= Time.deltaTime;

        if (_timer.Time < 0f)
        {
            float distance = (_transform.position - _ai.destination).sqrMagnitude;

            if(distance > _maxDistance * _maxDistance) 
            {
                _ai.destination = _transform.position;
            }

            _timer.Time = _maxTime;
        }

        _animator.SetFloat("Speed", _ai.velocity.magnitude * Time.deltaTime);
    }

    public void Stop()
    {
        _ai.isStopped = true; 
    }
}
