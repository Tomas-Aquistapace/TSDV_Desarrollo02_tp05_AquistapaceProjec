using UnityEngine;

public class ShootingBombs : MonoBehaviour
{
    public Transform initialPos;
    public GameObject bulletPref;
    public PlayerStats player;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!player.GetIsDead())
            {
                GameObject go = Instantiate(bulletPref);
                go.transform.position = initialPos.transform.position;
                go.transform.forward = initialPos.forward;
            }
        }
    }
}
