using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTop : MonoBehaviour {
    public float force = 100.0f;
    public float forceRadius = 1.0f;
    public int scoreValue = 1000;
    private AudioSource audioSource;

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
                //Debug.Log("Ball Position:" + other.GetComponent<Rigidbody>().position.z);
                //Debug.Log("Tunnel Top Position:" + transform.position.z);

                other.GetComponent<Ball>().Direction = "back";
                other.GetComponent<Ball>().enterTunnel = true;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            else
            {
                other.GetComponent<Ball>().Direction = "forward";
                other.GetComponent<Ball>().enterTunnel = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        ScoreManager.score += scoreValue;
        ScoreManager.newScore = scoreValue;
        ScoreManager.scoreText = "TUNNEL";

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
