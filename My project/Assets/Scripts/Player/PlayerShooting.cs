using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private IWeapon _weapon;
    private Transform _cameraPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _weapon.PerformShot(_cameraPosition.position, _cameraPosition.forward);
        }
    }
}
