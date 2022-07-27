using UnityEngine;

public class RedBlock : Obstacle
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") &&
            collider.TryGetComponent(out PlayerLife player))
        {
            player.Damage();
            Destroy(gameObject);
        }
    }
}
