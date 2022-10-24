using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerPrefab;
    private readonly Vector3 _startPosition = new Vector3(0, -2, 0);

    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefabForComponent<PlayerMovement>(_playerPrefab, _startPosition, Quaternion.identity, null);
        Container.Bind<IMovable>().To<PlayerMovement>().FromInstance(playerInstance).AsSingle();

        var playerLife = playerInstance.GetComponent<PlayerLife>();
        Container.Bind<ILifeUpdatable>().To<PlayerLife>().FromInstance(playerLife).AsSingle();
    }
}