using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField] private GameObject _decalPrefab;
    [SerializeField, Range(1, 20)] private int _decalAmount;
    [SerializeField] private GameObject _shellPrefab;
    [SerializeField, Range(1, 20)] private int _shellAmount;

    public override void InstallBindings()
    {
        Container.Bind<PoolableFactory>().AsSingle().WithArguments(_decalPrefab, _shellPrefab);
        Container.Bind<ObjectPool>().AsSingle().WithArguments(_shellPrefab, _shellAmount).WhenInjectedInto<Shotgun>();
    }
}