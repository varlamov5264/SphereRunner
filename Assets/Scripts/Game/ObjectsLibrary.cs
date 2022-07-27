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

    public GreenBlock GetGreenBlock() => GetBlock(_greenBlock);

    public RedBlock GetRedBlock() => GetBlock(_redBlock);

    private T GetBlock<T>(T blockPrefab) where T: MonoBehaviour 
    {
        var newBlock = Instantiate(blockPrefab);
        newBlock.gameObject.SetActive(true);
        return newBlock;
    }
}