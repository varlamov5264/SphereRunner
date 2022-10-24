using UnityEngine;
using Zenject;

public class ObjectsLibrary : MonoBehaviour
{
    [SerializeField] private GreenBlock _greenBlock;
    [SerializeField] private RedBlock _redBlock;
    [Inject] private DiContainer _diContainer;

    public Obstacle GetRandomObstacle()
    {
        var random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                return GetGreenBlock();
            case 1:
                return GetRedBlock();
            default:
                return null;
        }
    }

    public GreenBlock GetGreenBlock() => GetObstacle(_greenBlock);

    public RedBlock GetRedBlock() => GetObstacle(_redBlock);

    private T GetObstacle<T>(T blockPrefab) where T: Obstacle 
    {
        var newBlock = _diContainer.InstantiatePrefabForComponent<T>(blockPrefab);
        newBlock.gameObject.SetActive(true);
        return newBlock;
    }
}