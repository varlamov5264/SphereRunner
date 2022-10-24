using UnityEngine;
using Zenject;

public class AreaInstaller : MonoInstaller
{
    [SerializeField] private Area _area;

    public override void InstallBindings()
    {
        Container.Bind<Area>().FromInstance(_area).AsSingle();
    }
}