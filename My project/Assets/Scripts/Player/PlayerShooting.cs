using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Shotgun _shotGun;
    [SerializeField] private Transform _cameraPosition;
    private IWeapon _weapon;
    private Coroutine _coroutine;

    private void Start()
    {
        _weapon = _shotGun;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _weapon.IsReadyToShot())
        {
            _weapon.PerformShot(_cameraPosition.position, _cameraPosition.forward);
            _coroutine = null;
        }
        if (_weapon.IsReadyToShot() == false)
        {
            _coroutine ??= StartCoroutine(_weapon.Reload());
        }
    }
}
