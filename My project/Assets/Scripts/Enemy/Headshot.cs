using UnityEngine;

public class Headshot : MonoBehaviour
{
    private ZombieHealth _health;

    private void Awake()
    {
        _health = GetComponentInParent<ZombieHealth>();
    }

    public void TakeHeadshot(int damage)
    {
        _health.TakeDamage(damage);
    }
}
