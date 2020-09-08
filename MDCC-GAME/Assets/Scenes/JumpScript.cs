using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class JumpScript : MonoBehaviour {

    // set variables 
    public float scaleSpeed = 3f;

    public int jumpTime = 50;
    public int jumpSpeed = 1;
    public int jumpCount = 0;

    public bool onGround = true;
    
    public bool jU= false;
    public bool jD = false;

    public float upSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // hahahahahahahahahahahha i should probably put those variables in here but this is working so -_(*-*)_-
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        Vector3 pos = transform.position;

        // checking to see if jumpCount is 0, if so the obj is on ground
        if (jumpCount > 0)
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }

        

        // checking if key is down or not
        if (Input.GetKeyDown("space"))
        {
            if (jumpCount == 0)
            {
                jU = true;
                jD = false;
            }
        }
        else
        {

        }

        // if jumping up
        if (jU == true)
        {
            if (jumpCount < jumpTime)
            {
                jumpCount += jumpSpeed;
                scale.x += scaleSpeed * Time.deltaTime;
                scale.y += scaleSpeed * Time.deltaTime;
                pos.y += upSpeed * Time.deltaTime;
            }

            if (jumpCount == jumpTime)
            {
                jU = false;
                jD = true;
            }
        }

        // if going down
        if (jD == true)
        {
            if (onGround != true)
            {
                jumpCount -= jumpSpeed;
                scale.x -= scaleSpeed * Time.deltaTime;
                scale.y -= scaleSpeed * Time.deltaTime;
                pos.y -= upSpeed * Time.deltaTime;
            }
        }

        // move the obj
        transform.position = pos;
        transform.localScale = scale;
    } 
}
