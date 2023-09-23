using Zenject;
using UnityEngine;

public class ShotgunInstaller : MonoInstaller
{
    [SerializeField] private Shotgun _shotgun;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Shotgun>().FromInstance(_shotgun);
    }
}