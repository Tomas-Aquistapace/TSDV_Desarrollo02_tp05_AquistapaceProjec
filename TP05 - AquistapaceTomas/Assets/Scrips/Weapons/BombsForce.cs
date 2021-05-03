using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsForce : MonoBehaviour
{
    public Rigidbody rig;
    public float force = 20f;
    public float damage = 10f;

    public Target.Type type;

    void Start()
    {
        rig.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        Target target = collision.transform.GetComponent<Target>();

        if (target != null && target.type == type)
        {
            target.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
