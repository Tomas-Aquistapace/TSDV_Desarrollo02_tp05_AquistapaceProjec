using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum Type {
        mob,
        bomb
    }
    public Type type;

    public float health = 100f;

    public void IsDamaged(float amount)
    {
        health -= amount;

        if (health <= 0f)
            Dead();
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
