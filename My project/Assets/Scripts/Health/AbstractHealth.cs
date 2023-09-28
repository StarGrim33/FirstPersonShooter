using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    protected float _maxHealth;
    protected float _currenHealth;
    protected float _armor;

    protected void OnEnable()
    {
        _maxHealth = _unit.Config.Health;
        _currenHealth = _maxHealth;
        _armor = _unit.Config.Armor;
    }

    protected virtual void Die() { }
}
