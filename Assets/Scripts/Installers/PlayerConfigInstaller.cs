using UnityEngine;
using Zenject;

public class PlayerConfigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputController>().To<TouchInput>().AsSingle();
        Container.Bind<ISpeedLogic>().To<SpeedByPoints>().AsSingle();
    }
}