using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsForce : MonoBehaviour
{
    public Rigidbody rig;
    public float force = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rig.AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
