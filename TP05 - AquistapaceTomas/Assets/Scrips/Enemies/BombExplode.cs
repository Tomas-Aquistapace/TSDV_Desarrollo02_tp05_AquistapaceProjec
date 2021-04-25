using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public GameObject baseObj;
    public GameObject flareVFX;
    public GameObject explosionVFX;
    public Transform flameSpawn;
    public float damage = 40f;
    public float timeToExplode = 3f;

    float timeCount;
    bool activate;
    GameObject flare;
    GameObject explosion;

    void Start()
    {
        timeCount = 0f;
        activate = false;
    }

    void Update()
    {
        Explosion();
    }

    private void FixedUpdate()
    {
        if (activate)
            timeCount += 1f * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.transform.GetComponent<PlayerStats>();

        if (player != null)
        {
            activate = true;
            flare = Instantiate(flareVFX, flameSpawn.position, Quaternion.LookRotation(flameSpawn.forward));
            Destroy(flare, timeToExplode);
        }
    }

    void OnTriggerStay(Collider other)
    {
        PlayerStats player = other.transform.GetComponent<PlayerStats>();

        if (activate == true && timeCount >= timeToExplode)
        {
            if (player != null)
            {
                player.IsDamaged(damage);
                Debug.Log(player.health);
            }
        }
    }

    void Explosion()
    {
        if (activate == true && timeCount >= timeToExplode)
        {
            explosion = Instantiate(explosionVFX, baseObj.transform.position, Quaternion.LookRotation(baseObj.transform.forward));
            Destroy(explosion, 4f);

            Destroy(baseObj);
        }
    }
}
