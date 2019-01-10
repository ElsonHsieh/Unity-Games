using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBumper : MonoBehaviour {

    public float force = 100.0f;
    public float forceRadius = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {

            if (col.GetComponent<Rigidbody>())
            {
                //col.GetComponent<Rigidbody>().AddForce(transform.forward * force);
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);

            }
        }
        
    }

}
