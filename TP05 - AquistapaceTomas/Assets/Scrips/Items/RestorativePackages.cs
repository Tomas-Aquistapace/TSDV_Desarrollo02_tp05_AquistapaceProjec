using UnityEngine;

public class RestorativePackages : MonoBehaviour
{
    public enum Type {
        Healer,
        Armor
    }
    public Type type;
    
    public float amountHealth = 50f;
    public float amountArmor = 10f;

    void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.transform.GetComponent<PlayerStats>();

        if (player != null)
        {
            switch (type)
            {
                case Type.Healer:

                    player.RestoreHealth(amountHealth);

                    Debug.Log(player.health);

                    break;
                case Type.Armor:

                    player.RestoreArmor(amountArmor);

                    Debug.Log(player.armor);

                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
