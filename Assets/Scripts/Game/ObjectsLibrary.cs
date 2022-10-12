using UnityEngine;

public class ObjectsLibrary : Singleton<ObjectsLibrary>
{
    [SerializeField] private GreenBlock _greenBlock;
    [SerializeField] private RedBlock _redBlock;

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
        var newBlock = Instantiate(blockPrefab);
        newBlock.gameObject.SetActive(true);
        return newBlock;
    }
}