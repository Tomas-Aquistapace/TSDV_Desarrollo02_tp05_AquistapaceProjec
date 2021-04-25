using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsForce : MonoBehaviour
{
    public Rigidbody rig;
    public float force = 20f;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rig.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        Target target = collision.transform.GetComponent<Target>();

        //Debug.Log(target.type);

        if (target != null && target.type == Target.Type.bomb)
        {
            target.IsDamaged(damage);
            Destroy(this.gameObject);

            Debug.Log(target.health);
        }
        else
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
