using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }

    private void BindInput()
    {
        RuntimePlatform platform = Application.platform;

        if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor ||
            platform == RuntimePlatform.OSXPlayer || platform == RuntimePlatform.OSXEditor ||
            platform == RuntimePlatform.LinuxPlayer || platform == RuntimePlatform.LinuxEditor)
        {
            Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle();
            Debug.Log(platform);
        }
    }
}