using UnityEngine;
using Zenject;

public class LibraryInstaller : MonoInstaller
{
    [SerializeField] private ObjectsLibrary _objectsLibrary;

    public override void InstallBindings()
    {
        Container.Bind<ObjectsLibrary>().FromInstance(_objectsLibrary).AsSingle();
    }
}