﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Basic Stats")]
    public float health = 100f;
    public float armor = 50f;

    public float MaxHealth = 100f;
    public float MaxArmor = 50f;

    [Header("Poits")]
    public float totalPoints = 0f;
    public int totalKills = 0;

    bool isDead;

    void Start()
    {
        isDead = false;
        totalPoints = 0;
    }

    public void IsDamaged(float amount)
    {
        if (armor > 0)
        {
            armor -= amount;
            if (armor < 0)
            {
                amount = armor * -1;
                armor = 0;
            }
        }

        if (armor <= 0)
        {
            health -= amount;
            if (health <= 0)
            {
                SetIsDead(true);
            }
        }

    }

    public void RestoreHealth(float amount)
    {
        if (health < MaxHealth)
        {
            health += amount;

            if (health > MaxHealth)
                health = MaxHealth;
        }
    }

    public void RestoreArmor(float amount)
    {
        if (armor < MaxArmor)
        {
            armor += amount;

            if (armor > MaxArmor)
                armor = MaxArmor;
        }
    }

    public void SetPoints(float amount) { totalPoints += amount; }

    public void SetKills() { totalKills++; }

    public void SetIsDead(bool value) { isDead = value; }

    public bool GetIsDead() { return isDead; }
}