using UnityEngine;

[CreateAssetMenu(menuName = "Source/Units/Config", fileName = "UnitConfig", order = 0)]
public class UnitConfig : ScriptableObject
{
    [Header("[Name]"), Space]
    [SerializeField] private string _unitName;

    [Header("[Common]"), Space]
    [SerializeField, Min(0)] private float _health;
    [SerializeField, Min(0)] private float _speed;
    [SerializeField, Min(0)] private float _armor;
    [SerializeField, Min(0)] private float _strafeSpeed;
    [SerializeField, Min(0)] private float _jumpForce;
    [SerializeField, Min(0)] private float _jumpCooldown;

    public string UnitName => _unitName;

    public float Health => _health;

    public float Speed => _speed;

    public float Armor => _armor;

    public float StrafeSpeed => _strafeSpeed;

    public float JumpSpeed => _jumpForce;

    public float JumpCooldown => _jumpCooldown;
}
