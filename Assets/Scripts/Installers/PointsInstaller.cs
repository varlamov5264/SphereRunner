using UnityEngine;
using Zenject;

public class PointsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PointsCollector>().FromNewComponentOnNewGameObject().AsSingle();
    }
}