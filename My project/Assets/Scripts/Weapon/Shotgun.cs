using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] private LayerMask _layerMask;

    private int _damage = 10;
    private int _ammo = 6;
    private int _currentAmmo;

    public int CurrentAmmo => _currentAmmo;

    public int MaxAmmo => _ammo;

    public event UnityAction<int> AmmoChanged;

    private void Start()
    {
        _currentAmmo = _ammo;
        AmmoChanged?.Invoke(_currentAmmo); 
    }

    public void PerformShot(Vector3 startPosition, Vector3 direction)
    {
        _currentAmmo--;
        AmmoChanged?.Invoke(CurrentAmmo);

        if(Physics.Raycast(startPosition, direction, out RaycastHit hit, 50, _layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable component))
            {
                component.TakeDamage(_damage);
            }
        }
    }

    public IEnumerator Reload()
    {
        var waitForSeconds = new WaitForSeconds(2);
        yield return waitForSeconds;
        _currentAmmo = _ammo;
        AmmoChanged?.Invoke(CurrentAmmo);
    }

    public bool IsReadyToShot()
    {
        return _currentAmmo > 0;
    }
}
