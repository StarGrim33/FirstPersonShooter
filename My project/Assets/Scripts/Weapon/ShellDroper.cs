using UnityEngine;
using Zenject;

public class ShellDroper : MonoBehaviour
{
    [SerializeField] private Rigidbody _shellPrefab;
    [SerializeField] private Transform _shellTransform;
    [SerializeField] private float _shellSpeed;
    [SerializeField] private float _shellAngular;
    [SerializeField] private Shotgun _shotGun;

    private ObjectPool _pool;

    [Inject]
    private void Construct(ObjectPool objectPool)
    {
        _pool = objectPool;
    }

    private void OnEnable()
    {
        _shotGun.Shooting += Shooting;
    }

    private void OnDisable()
    {
        _shotGun.Shooting -= Shooting;
    }

    private void Shooting()
    {
        var instance = _pool.GetObject(PoolableObjects.Shell);
        var shell = Instantiate(_shellPrefab, _shellTransform.position, _shellTransform.rotation);
        shell.velocity = _shellTransform.forward * _shellSpeed;
        shell.angularVelocity = Vector3.up * _shellAngular;
    }
}
