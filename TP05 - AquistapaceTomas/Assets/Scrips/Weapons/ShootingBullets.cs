using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject impactVFX;
    public Transform rayWeapon;
    public float range = 100f;

    public float damage = 10f;

    public PlayerStats player;

    public Target.Type type;

    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (!player.GetIsDead())
            {
                RaycastHit hit;
                
                if (Physics.Raycast(rayWeapon.position, rayWeapon.forward, out hit, range))
                {
                    Target target = hit.transform.GetComponent<Target>();

                    if (target != null && target.type == type)
                    {
                        target.TakeDamage(damage);
                    }

                    GameObject impactGO = Instantiate(impactVFX, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 1f);
                }
            }
        }
    }
}
