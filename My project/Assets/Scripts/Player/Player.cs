using UnityEngine;

public class Player : Unit
{
    private CharacterController _charachterController;

    public UnitConfig BaseConfig => Config;

    private void Awake()
    {
        _charachterController = GetComponent<CharacterController>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.right + Vector3.forward + Vector3.up * _charachterController.height);
    }
}
