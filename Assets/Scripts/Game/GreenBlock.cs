using UnityEngine;

public class GreenBlock : Obstacle
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") &&
            collider.TryGetComponent(out PlayerMovement player))
        {
            PointsCollector.Instance.Add(1);
            Destroy(gameObject);
        }
    }
}
