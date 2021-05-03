using UnityEngine;

public class Target : MonoBehaviour, IDamaged
{
    public delegate void DeadEvent(float points);
    public static DeadEvent Dead;
    
    public enum Type {
        mob,
        bomb
    }
    [Header("Mob Stats")]
    public Type type;

    public float health = 100f;
    public float points = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
            Die();
    }

    void Die()
    {
        Dead(points);
        Destroy(gameObject);
    }
}
