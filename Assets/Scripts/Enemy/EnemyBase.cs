using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private float Health = 100f;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
