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
    private DecalSpawner _decalSpawner;
    private int _damage = 40;
    private int _criticalDamage = 100;
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

    private void Awake()
    {
        _decalSpawner = new DecalSpawner();
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

        if (Physics.Raycast(startPosition, direction, out RaycastHit hit, 50, _layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable component))
            {
                component.TakeDamage(_damage);

                if (component.IsApplyableForce())
                {
                    var victim = hit.rigidbody;
                    victim.AddForceAtPosition(direction * _impactForce, hit.point, ForceMode.Impulse);
                }
            }
            else if (hit.collider.TryGetComponent<Headshot>(out Headshot headshot))
            {
                headshot.TakeHeadshot(_criticalDamage);
            }
            else if (hit.collider.TryGetComponent<Destructible>(out Destructible destructible))
            {
                destructible.Destruct();
            }

            var layer = hit.collider.gameObject.layer;
            _decalSpawner.SpawnDecal(layer, _objectPool, hit, _offSet);
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
