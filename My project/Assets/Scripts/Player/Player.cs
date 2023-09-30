using UnityEngine;

public class Player : Unit
{
    [SerializeField] private CharacterController _charachterController;

    public UnitConfig BaseConfig => Config;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.right + Vector3.forward + Vector3.up * _charachterController.height);
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if(hit.rigidbody != null)
    //    {
    //        hit.rigidbody.AddForce(Vector3.one, ForceMode.Impulse);
    //    }
    //}
}
