using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    private Rigidbody[] _rigigbodies;
    private Animator _animator;
    private AiNavigator _aiNavigator;

    private void Awake()
    {
        _rigigbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        _aiNavigator = GetComponent<AiNavigator>();
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
        _aiNavigator.Stop();

        foreach( var rigidbody in _rigigbodies)
        {
            rigidbody.isKinematic = false;
        }

        _animator.enabled = false;
    }
}
