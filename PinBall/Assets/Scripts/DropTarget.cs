using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTarget : MonoBehaviour {

    public float dropDistance = 1.0f;
    public int bankID = 0;
    public float resetDelay = 0.5f;
    private bool isDropped = false;
    public int scoreValue = 100;
    public int bankValue = 3000;
    static List<DropTarget> dropTargets = new List<DropTarget>();
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        dropTargets.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(!isDropped)
        {
            transform.position += Vector3.down * dropDistance;
            isDropped = true;
            ScoreManager.score += scoreValue;
            ScoreManager.newScore = scoreValue;
            ScoreManager.scoreText = "TARGET";
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();


            //Check to see if the rest of the bank has been dropped
            bool resetBank = true;
            foreach(DropTarget target in dropTargets)
            {
                if(target.bankID == bankID)
                {
                    if(!target.isDropped)
                    {
                        resetBank = false;
                    }
                }
            }

            //Reset all drop targets in bank if the bank has been dropped
            if (resetBank)
            {
                ScoreManager.score += bankValue;
                ScoreManager.newScore = bankValue;
                ScoreManager.scoreText = "ALL\nTARGET";
                Invoke("ResetBank", resetDelay);
            }
        }
    }

    public void ResetBank()
    {
        foreach (DropTarget target in dropTargets)
        {
            if (target.bankID == bankID)
            {
                target.transform.position += Vector3.up * dropDistance;
                target.isDropped = false;
            }
        }
    }
}
