using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    public enum Type {
        mob,
        bomb
    }
    [Header("Mob Stats")]
    public Type type;

    public float health = 100f;
    public float points = 100f;

    public void IsDamaged(float amount)
    {
        health -= amount;

        if (health <= 0f)
            Dead();
    }

    void Dead()
    {
        player.GetComponent<PlayerStats>().SetPoints(points);
        player.GetComponent<PlayerStats>().SetKills();
        Destroy(gameObject);
    }
}
