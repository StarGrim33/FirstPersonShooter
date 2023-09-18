using System;
using UnityEngine;

public class BoxHealth : AbstractHealth, IDamageable
{
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

    protected override void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentException("Value cannot be negative", nameof(damage));

        CurrentHealth -= damage;
        Debug.Log($"Health is {CurrentHealth}");
    }
}
