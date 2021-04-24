using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;

    void Start()
    {
        Weapon1.SetActive(true);
        Weapon2.SetActive(false);
    }

    void Update()
    {
        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown("1"))
        {
            Weapon2.SetActive(false);
            Weapon1.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
        }
    }
}
