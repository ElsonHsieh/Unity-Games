using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceAtOffset : MonoBehaviour {

    public string flipper;
    public float force = 100;
    public Vector3 forceDirection = Vector3.forward;
    public string buttonName = "Fire1";
    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButton(buttonName))
        if (Input.GetKey(KeyCode.F) && flipper == "Left" ||
            Input.GetKey(KeyCode.J) && flipper == "Right")

        {
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * -force, transform.position + offset);
        }
	}
}
