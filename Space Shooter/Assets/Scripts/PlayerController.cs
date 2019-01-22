using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
 //       if(Input.GetButton("Fire2") && Time.time > nextFire)
          if (Input.GetKey(KeyCode.F) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioSource audioData = GetComponent<AudioSource>();
            audioData.Play(0);
           
        }
        //Instantiate(shot, shotSpawn.position, shotSpawn.rotation)
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal*speed, 0.0f, moveVertical*speed);
        rb.velocity = movement;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
