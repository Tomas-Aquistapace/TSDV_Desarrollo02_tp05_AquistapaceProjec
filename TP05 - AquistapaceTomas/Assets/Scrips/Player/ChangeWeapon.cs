using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject Weapon_1;
    public GameObject Weapon_2;

    void Start()
    {
        Weapon_1.SetActive(true);
        Weapon_2.SetActive(false);
    }

    void Update()
    {
        ChangeWeapons();
    }

    void ChangeWeapons()
    {
        if (Input.GetKeyDown("1"))
        {
            Weapon_2.SetActive(false);
            Weapon_1.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            Weapon_1.SetActive(false);
            Weapon_2.SetActive(true);
        }
    }
}
