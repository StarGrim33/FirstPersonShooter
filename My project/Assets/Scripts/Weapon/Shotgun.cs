using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _decal;
    [SerializeField] private float _offSet;

    private ObjectPool _objectPool;
    private int _damage = 10;
    private int _ammo = 6;
    private int _currentAmmo;
    private int _impactForce = 8;

    public int CurrentAmmo => _currentAmmo;

    public int MaxAmmo => _ammo;

    public event UnityAction<int> AmmoChanged;

    public event UnityAction Reloading;

    public event UnityAction Shooting;

    [Inject]
    private void Construct(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    private void Start()
    {
        _currentAmmo = _ammo;
        AmmoChanged?.Invoke(_currentAmmo); 
    }

    public void PerformShot(Vector3 startPosition, Vector3 direction)
    {
        _currentAmmo--;
        AmmoChanged?.Invoke(CurrentAmmo);
        Shooting?.Invoke();

        if(Physics.Raycast(startPosition, direction, out RaycastHit hit, 50, _layerMask, QueryTriggerInteraction.Ignore))
        {
            var decal = _objectPool.GetObject(PoolableObjects.Decal);
            decal.gameObject.transform.position = hit.point + hit.normal * _offSet;
            decal.gameObject.transform.LookAt(hit.point);
            decal.transform.rotation = Quaternion.LookRotation(hit.normal);

            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable component))
            {
                component.TakeDamage(_damage);
                var victim = hit.rigidbody;
                victim.AddForceAtPosition(direction * _impactForce, hit.point, ForceMode.Impulse);
            }
        }
    }

    public IEnumerator Reload()
    {
        Reloading?.Invoke();
        var waitForSeconds = new WaitForSeconds(3);
        yield return waitForSeconds;
        _currentAmmo = _ammo;
        AmmoChanged?.Invoke(CurrentAmmo);
    }

    public bool IsReadyToShot()
    {
        return _currentAmmo > 0;
    }
}
