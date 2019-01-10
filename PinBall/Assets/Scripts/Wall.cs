using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public float force = 100;
    public float forceRadius = 1.0f;
    public Vector3 forceDirection = Vector3.forward.normalized;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {

            if (col.GetComponent<Rigidbody>())
            {
                //col.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward.normalized * force, transform.position);
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
                //col.GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
            }
        }
    }

}
