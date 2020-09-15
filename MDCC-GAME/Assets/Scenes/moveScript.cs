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

    public int count = 0;
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
            //if (Math.Abs(speedx) < speedCap)
            //{
                count++;
                if (Input.GetKey("a"))
                {
                    if (speedx > (speedCap * -1))
                    {
                        speedx = speedx - accel;
                    }
                }
                if (Input.GetKey("d"))
                {
                if (speedx < speedCap)
                    {
                        speedx = speedx + accel;
                    }
                }
                //Debug.Log(count + ": Speed: x" + speedx);
            //}
        }
        else
        {
            if (Math.Abs(speedx) != 0)
            {
                if (speedx > 0)
                {
                    speedx = speedx - (accel);
                }
                if (speedx < 0)
                {
                    speedx = speedx + (accel);
                }
            }
            else
            {
                speedx = 0;
            }
        }

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            //if (Math.Abs(speedy) < speedCap)
            //{
                count++;
                if (Input.GetKey("s"))
                {
                    if (speedy > (speedCap * -1))
                    {
                        speedy = speedy - accel;
                    }
                }
                if (Input.GetKey("w"))
                {
                    if (speedy < speedCap)
                    {
                        speedy = speedy + accel;
                    }
                }
                //Debug.Log(count + ": Speed y: " + speedy);
            //}
        }
        else
        {
            if (Math.Abs(speedy) != 0)
            {
                if (speedy > 0)
                {
                    speedy = speedy - (accel);
                }
                if (speedy < 0)
                {
                    speedy = speedy + (accel);
                }
            }
            else
            {
                speedy = 0;
            }
        }
        
        pos.y += speedy * Time.deltaTime;
        pos.x += speedx * Time.deltaTime;

        transform.position = pos;
    }
}
