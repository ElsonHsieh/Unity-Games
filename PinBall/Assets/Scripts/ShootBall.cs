using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {

    public float force = 100.0f;
    public string buttonName = "Fire1";

    private List<Rigidbody> ballList = new List<Rigidbody>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown(buttonName))
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach(Rigidbody ball in ballList)
            {
                //ball.AddForce(Vector3.forward * force);
                ball.AddForceAtPosition(Vector3.forward.normalized * force, transform.position);

            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Object Entered");
        if(col.GetComponent<Rigidbody>())
        {
            Debug.Log("Object has rigidbody");
            ballList.Add(col.GetComponent<Rigidbody>());
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Object Exited ");
        if (col.GetComponent<Rigidbody>())
        {
            Debug.Log("Object has rigidbody");

            ballList.Remove(col.GetComponent<Rigidbody>());
        }
    }

}
