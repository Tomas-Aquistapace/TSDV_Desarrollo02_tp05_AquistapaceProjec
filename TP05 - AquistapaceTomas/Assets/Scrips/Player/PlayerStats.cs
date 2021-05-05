using UnityEngine;

public class PlayerStats : MonoBehaviour , IDamaged
{
    public delegate void RefreshValues();
    public static RefreshValues RefreshLife;
    public static RefreshValues RefreshPoints;
    public static RefreshValues RefreshFinalPoints;

    [Header("Basic Stats")]
    public float health = 100f;
    public float armor = 50f;

    public float MaxHealth = 100f;
    public float MaxArmor = 50f;

    [Header("Poits")]
    public float totalPoints = 0f;
    public int totalKills = 0;

    bool isDead;

    void OnEnable()
    {
        Target.Dead += SetKills;
        Target.Dead += SetPoints;
    }

    void OnDisable()
    {
        Target.Dead -= SetKills;
        Target.Dead -= SetPoints;
    }

    void Start()
    {
        isDead = false;
        totalPoints = 0;
    }

    public void TakeDamage(float amount)
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
                SetHighScore();
            }
        }

        RefreshLife();
    }

    public void RestoreHealth(float amount)
    {
        if (health < MaxHealth)
        {
            health += amount;

            if (health > MaxHealth)
                health = MaxHealth;
        }

        RefreshLife();
    }

    public void RestoreArmor(float amount)
    {
        if (armor < MaxArmor)
        {
            armor += amount;

            if (armor > MaxArmor)
                armor = MaxArmor;
        }

        RefreshLife();
    }

    public void SetPoints(float amount)
    {
        totalPoints += amount;
        RefreshPoints();
    }

    public void SetKills(float unused)
    {
        totalKills++;
        RefreshPoints();
    }

    public void SetIsDead(bool value)
    {
        isDead = value;
        RefreshFinalPoints();
    }

    public bool GetIsDead() { return isDead; }

    public void SetHighScore()
    {
        if (SingletonManager.Instance.highScore < totalPoints)
        {
            SingletonManager.Instance.highScore = totalPoints;
        }
    }
}
