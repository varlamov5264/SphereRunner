using UnityEngine;

public class RedBlock : Obstacle
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") &&
            collider.TryGetComponent(out IDamageable player))
        {
            player.Damage();
            Destroy(gameObject);
        }
    }
}
