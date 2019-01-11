using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public float force = 100.0f;
    public float forceRadius = 1.0f;
    public int scoreValue = 100;
    private AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {

            if (col.GetComponent<Rigidbody>())
            {
                col.GetComponent<Rigidbody>().transform.position = new Vector3(col.GetComponent<Rigidbody>().transform.position.x, 0.5f, col.GetComponent<Rigidbody>().transform.position.z);
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
                ScoreManager.score += scoreValue;
                ScoreManager.newScore = scoreValue;
                ScoreManager.scoreText = "BUMPER";
                Invoke("ResetBank", 2.0f);
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
