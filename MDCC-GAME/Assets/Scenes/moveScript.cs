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

    public bool movingL = false;
    public bool movingR = false;
    public bool movingU = false;
    public bool movingD = false;

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

        if (Input.GetKey("a")){
            movingL = true;
            movingR = false;
        }
        else
        {
            movingL = false;
        }
        if (Input.GetKey("d"))
        {
            movingL = false;
            movingR = true;
        }
        else
        {
            movingR = false;
        }
        if (Input.GetKey("w"))
        {
            movingU = true;
            movingD = false;
        }
        else
        {
            movingU = false;
        }
        if (Input.GetKey("s"))
        {
            movingU = false;
            movingD = true;
        }
        else
        {
            movingD = false;
        }

        /*
        if (movingL == true)
        {
            if (Math.Abs(speedx) < speedCap)
            {
                count++;
                speedx = speedx - accel;
            }
        else
        {

        }

        if (movingR == true)
        {
            if (Math.Abs(speedx) < speedCap)
            {
                speedx = speedx + accel;
            }
        }
        else
        {

        }

        if (movingU == true)
        {

        }
        else
        {

        }

        if (movingD == true)
        {

        }
        else
        {

        }
        */
        
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            if (Math.Abs(speedx) < speedCap)
            {
                count++;
                if (Input.GetKey("a"))
                {
                    speedx = speedx - accel;
                }
                if (Input.GetKey("d"))
                {
                    speedx = speedx + accel;
                }
                Debug.Log(count + ": Speed: x" + speedx);
            }
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
            if (Math.Abs(speedy) < speedCap)
            {
                count++;
                if (Input.GetKey("s"))
                {
                    speedy = speedy - accel;
                }
                if (Input.GetKey("w"))
                {
                    speedy = speedy + accel;
                }
                Debug.Log(count + ": Speed y: " + speedy);
            }
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
