using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : AbstractHealth, IDamageable
{
    public event UnityAction<float, float> OnHealthChanged;

    public event UnityAction PlayerDead;

    public float MaxHealth => _maxHealth;

    public float CurrentHealth
    {
        get
        {
            return _currenHealth;
        }
        private set
        {
            _currenHealth = Mathf.Clamp(value, 0, _maxHealth);

            if (_currenHealth <= 0)
                Die();
        }
    }

    public Transform TargetTransform => transform;

    public bool IsAlive => _currenHealth > 0;

    protected override void Die()
    {
        //_animator.SetTrigger(Constants.DeadState);
        //StateManager.Instance.SetState(GameStates.Paused);
        PlayerDead?.Invoke();
    }

    public bool IsApplyableForce() => false;

    public void TakeDamage(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Value cannot be negative", nameof(value));

        CurrentHealth -= value;
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        Debug.Log($"Health is {CurrentHealth}");
    }
}
