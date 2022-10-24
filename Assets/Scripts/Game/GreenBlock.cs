using UnityEngine;

public class GreenBlock : Obstacle
{
    [Zenject.Inject] private PointsCollector _pointsCollector;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") &&
            collider.TryGetComponent(out IMovable movable))
        {
            _pointsCollector.Add(1);
            Destroy(gameObject);
        }
    }
}
