using UnityEngine;
using UnityEngine.AI;

public class RagdollHandler : MonoBehaviour
{
    private Rigidbody[] _rigigbodies;
    private Animator _animator;
    private AiNavigator _aiNavigator;
    private NavMeshAgent _agent;
    private CapsuleCollider _capsuleCollider;

    private void Awake()
    {
        _rigigbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        _aiNavigator = GetComponent<AiNavigator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _agent = GetComponent<NavMeshAgent>();
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach(var rigidbody in _rigigbodies)
        {
            rigidbody.isKinematic = true;
        }

        _animator.enabled = true;
    }

    public void ActivateRagdoll()
    {
        foreach( var rigidbody in _rigigbodies)
        {
            rigidbody.isKinematic = false;
        }

        _animator.enabled = false;
        _agent.enabled = false;
        _capsuleCollider.enabled = false;
    }
}
