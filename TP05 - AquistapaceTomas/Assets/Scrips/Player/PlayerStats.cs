using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    public float armor = 50f;


    public void IsDamaged(float amount)
    {
        health -= amount;
    }
}
