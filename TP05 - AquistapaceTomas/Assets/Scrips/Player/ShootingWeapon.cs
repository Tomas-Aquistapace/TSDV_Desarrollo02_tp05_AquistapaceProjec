using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour
{
    public Transform rayWeapon;
    public float range = 100f;

    public float damage = 10f;

    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(rayWeapon.position, rayWeapon.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();

                if (hit.transform.GetComponent<Target>() != null)
                {
                    target.IsDamaged(damage);
                    Debug.Log(target.health);
                }
            }
        }

        //Debug.DrawRay(rayWeapon.position, rayWeapon.forward * range, Color.blue);
    }
}
