using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField] private GameObject _decalPrefab;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPool<Decal>>().AsSingle().WithArguments(_decalPrefab, 10).WhenInjectedInto<Shotgun>();
    }
}