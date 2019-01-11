using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour {

    public float force = 100.0f;
    public float forceRadius = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
            {
                if (other.GetComponent<Ball>().enterTunnel == false)
                {
                    other.GetComponent<Ball>().enterTunnel = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    if (other.GetComponent<Rigidbody>().position.z <= transform.position.z)
                    {
                        other.GetComponent<Ball>().Direction = "forward";
                    other.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
                    }
                    else
                    {
                        other.GetComponent<Ball>().Direction = "";
                    }
                }
                else
                {
                    other.GetComponent<Ball>().enterTunnel = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                //other.transform.position = new Vector3(other.transform.position.x, 0.5f, other.transform.position.z);
                }
            /*
            if (other.GetComponent<Rigidbody>().position.z <= transform.position.z)
            { 
                other.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Ball>().enterTunnel = true;

            //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }*/
            //other.GetComponent<Rigidbody>().AddExplosionForce(force, Vector3.back, forceRadius);
            //Debug.Log("Acce");

        }
        

    }   // Use this for initialization

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {

            //other.GetComponent<Ball>().enterTunnel = false;
            //other.transform.position = new Vector3(other.transform.position.x, 0.5f, other.transform.position.z);
            if (other.GetComponent<Rigidbody>().position.z <= transform.position.z)
            {
                other.GetComponent<Ball>().enterTunnel = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                //other.transform.position = new Vector3(other.transform.position.x, 0.5f, other.transform.position.z);
                //other.GetComponent<Ball>().enterTunnel = false;
                //other.transform.position = new Vector3(other.transform.position.x, 0.5f, other.transform.position.z);
                //other.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
                //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
            else
            {
                //other.transform.position = new Vector3(other.transform.position.x, 0.5f, other.transform.position.z);
            }
            //if (other.GetComponent<Rigidbody>().position.z <= transform.position.z)
            //{
            //    other.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            //    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            //}
            //else
            //{
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            //}
            //other.GetComponent<Rigidbody>().AddExplosionForce(force, Vector3.back, forceRadius);
            //Debug.Log("Acce");
        }


    }   // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
