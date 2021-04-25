using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBombs : MonoBehaviour
{
    public Transform initialPos;
    public GameObject bulletPref;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(bulletPref);
            go.transform.position = initialPos.transform.position;
            go.transform.forward = initialPos.forward;
        }
    }
}
