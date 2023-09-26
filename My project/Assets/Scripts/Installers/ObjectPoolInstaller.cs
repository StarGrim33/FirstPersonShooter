using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField, Range(1, 20)] private int _decalAmount;
    [SerializeField, Range(1, 20)] private int _shellAmount;
    [SerializeField] private PoolableFactory _poolFactory;

    public override void InstallBindings()
    {
        Container.Bind<PoolableFactory>().FromInstance(_poolFactory);
        Container.Bind<ObjectPool>().AsSingle().WithArguments(_poolFactory, _decalAmount, _shellAmount);
    }
}