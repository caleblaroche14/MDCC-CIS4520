using System.Collections;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speedCap = 10f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public float accel = 1f;
   // public float accelSpeed = 1.01f;
    public float jumpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {


    }



    // Update is called once per frame
    void FixedUpdate()
    {
         
        Vector3 pos = transform.position;



        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            if (Math.Abs(speedx) < speedCap)
            {
                speedx = speedx + accel;
                Debug.Log("Speed: " + speedx);
            }
        }
        else
        {
            // stuck here... MOVING NOT WORKING
            if (Math.Abs(speedx) > 0)
            {
                speedx = speedx - (accel);
            }
            else
            {
                speedx = 0;
            }
        }

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            if (speedy < speedCap)
            {
                speedy = speedy + accel;
                Debug.Log("Speed: " + speedy);
            }
        }
        else
        {
            if (speedy > 0)
            {
                speedy = speedy - (accel);
            }
            else
            {
                speedy = 0;
            }
        }
        
        if (Input.GetKey("w"))
        {
            if (speedy < 0)
            {
                //speedy = speedy * 1;
            }
            //pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            if (speedy > 0)
            {
                //speedy = speedy * -1;
            }
            // pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            if (speedx > 0)
            {
                speedx = speedx * -1;
            }
            //pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            if (speedx < 0)
            {
                speedx = speedx * 1;
            }
            //pos.x += speed * Time.deltaTime;
        }
        
        pos.y += speedy * Time.deltaTime;
        pos.x += speedx * Time.deltaTime;

        transform.position = pos;


        //Vector3 cameraPos = GameObject.Find("Main Camera").transform.position;
        //Vector3 playerPos = new Vector3(GameObject.Find("Main Camera").transform.position.x, gameObject.transform.position.y);
        //gameObject.transform.position = playerPos;
    }
}
