using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Basic Stats")]
    public float health = 100f;
    public float armor = 50f;

    public float MaxHealth = 100f;
    public float MaxArmor = 50f;

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
}
