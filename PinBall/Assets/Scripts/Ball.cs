using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool enterTunnel = false;
    public string Direction = "";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y == 1.25f && enterTunnel == true)
        {
            //this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1.01f);
        }
        if (transform.position.y > 1.25f && enterTunnel == true)
        {
            
            this.transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
        }
        if (transform.position.y < 1.25f && enterTunnel == true)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        }

        if (transform.position.y > 0.5f && enterTunnel == true)
        {
            //this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1.5f);
            if (Direction == "forward")
            {
                //this.GetComponent<Rigidbody>().AddForce(Vector3.back * 1.5f);
                this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1.5f);

            }
            else
            {
                this.GetComponent<Rigidbody>().AddForce(Vector3.back * 1.5f);

            }
        }

            if (transform.position.y > 0.5f && enterTunnel == false)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        }
        /*
        if (transform.position.y > 1.25f)
        {
            this.transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
            //this.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezePositionY);
            
        }
        if (transform.position.x > 0.5f)
        {
            //transform.position.Set(0.5f, transform.position.y, transform.position.z);
            
        }
        */
        //Debug.Log("y:"+this.transform.position.y);
        /*
	    if(GetComponent<Rigidbody>().transform.position.y > 1.25)
        {

            GetComponent<Rigidbody>().transform.position.Set(transform.position.x, 1.25f, transform.position.z);
        }*/
    }
}
