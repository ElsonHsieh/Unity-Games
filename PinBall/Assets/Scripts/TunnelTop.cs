using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTop : MonoBehaviour {
    public float force = 100.0f;
    public float forceRadius = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().position.z > transform.position.z)
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.back * force);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            if (other.GetComponent<Rigidbody>().position.z <= transform.position.z)
            {
                other.GetComponent<Ball>().enterTunnel = true;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            }
            else
            {
                other.GetComponent<Ball>().enterTunnel = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
