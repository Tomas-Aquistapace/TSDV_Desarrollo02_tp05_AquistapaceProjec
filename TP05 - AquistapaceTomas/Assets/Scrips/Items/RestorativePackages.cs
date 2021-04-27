using UnityEngine;

public class RestorativePackages : MonoBehaviour
{
    public enum Type {
        Healer,
        Armor,
        Points
    }
    public Type type;

    public float amount = 50f;

    void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.transform.GetComponent<PlayerStats>();

        if (player != null)
        {
            switch (type)
            {
                case Type.Healer:

                    player.RestoreHealth(amount);

                    break;
                case Type.Armor:

                    player.RestoreArmor(amount);

                    break;
                case Type.Points:

                    player.SetPoints(amount);

                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
