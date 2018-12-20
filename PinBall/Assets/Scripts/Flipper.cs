using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{

    public float maxAngle = 100.0f;
    public float flipTime = 1.0f;
    public string buttonName = "Fire1";
    public string flipper = "";
    public float hitWait = 0.5f;
    float currentAngle = 0;

    private decimal hitControl = 1;   //limit to just hit the ball for one time when the key is down 
    private Quaternion initialOrientation;

    // Use this for initialization
    void Start()
    {
        initialOrientation = transform.rotation;
        //transform.rotation = Quaternion.RotateTowards()
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F) && flipper == "Left" ||
            Input.GetKey(KeyCode.J) && flipper == "Right")
        {
            //Rotate the flipper

            //transform.Rotate(Vector3.right, -maxAngle);
            //maxAngle = maxAngle * -1;
            //transform.Rotate(Vector3.right, maxAngle / flipTime * Time.deltaTime);
            //currentAngle = transform.rotation.eulerAngles.y - initialOrientation.eulerAngles.y;
            if ( maxAngle - currentAngle > 0)
            {
                transform.Rotate(Vector3.left, maxAngle / flipTime);
                currentAngle += (maxAngle / flipTime);
            }
            else
            {
                //currentAngle = 0;
                //transform.rotation = initialOrientation;
            }
            Debug.Log(maxAngle - currentAngle+":"+ currentAngle+":"+transform.rotation.eulerAngles.y);


            //HitTheBall();
        }
        if (Input.GetKeyUp(KeyCode.F) && flipper == "Left" || 
            Input.GetKeyUp(KeyCode.J) && flipper == "Right")
        {
            //Rotate the flipper

            //transform.Rotate(Vector3.right, maxAngle);
            transform.rotation = initialOrientation;
            //maxAngle = maxAngle * -1;
            //transform.Rotate(Vector3.right, -20 * maxAngle / flipTime * Time.deltaTime);
            Debug.Log(hitControl);
            hitControl = 1;
            currentAngle = 0;
            //HitTheBall();
        }
    }
    IEnumerator HitTheBall()
    {
        hitWait = 0.0f;
        transform.Rotate(Vector3.right, -20 * maxAngle / flipTime * Time.deltaTime);
        Debug.Log(maxAngle / flipTime * Time.deltaTime);
        yield return new WaitForSeconds(hitWait);
        //transform.Rotate(Vector3.right, 20 * maxAngle / flipTime * Time.deltaTime);
 
    }
}