using System.Collections;
using System.Collections.Generic;
using System;
//using System.Random;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedCap = 4f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public float accelStart = 1f;
    private float accel;

    public float maxSpeedPercent = 10.25f;
    public float minSpeedPercent = .005f;
    //accel = accelStart;
    System.Random rnd = new System.Random();
    
    Vector3 playerPos;

    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        accel = UnityEngine.Random.Range((accelStart * minSpeedPercent), (accelStart * maxSpeedPercent));
        Debug.Log("accel: " + accel);
        //accelStart;//(rnd.Next((accelStart - 2), (accelStart + 2)));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        Vector3 pos = transform.position;

        // find player gameObj
        var playerZ = GameObject.Find("player");
        if (playerZ)
        {
            playerPos = playerZ.transform.position;
            //Debug.Log("Found Player");
        }
        else
        {
            //Debug.Log("Can't Find Player");
        }


        // go toward player

        // x axis

        float distanceX = Math.Abs(Math.Abs(playerPos.x) - Math.Abs(pos.x));
        float distanceY = Math.Abs(Math.Abs(playerPos.y) - Math.Abs(pos.y));
        //Debug.Log("Distance X from player: " + distanceX);
        //Debug.Log("Distance Y from player: " + distanceY);
        if (distanceX > .5)
        {
            //Debug.Log("far enough away x");

            if (playerPos.x < pos.x)
            {
                if (speedx > (speedCap * -1))
                {
                    speedx = speedx - accel;
                }
            }
            if (playerPos.x > pos.x)
            {
                if (speedx < speedCap)
                {

                    speedx = speedx + accel;
                }
            }
        }
        else
        {
            //Debug.Log("Not far enough away x");
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

        // y axis
        if (distanceY > .5)
        {
            //Debug.Log("far enough away x");

            if (playerPos.y < pos.y)
            {
                if (speedy > (speedCap * -1))
                {
                    speedy = speedy - accel;
                }
            }
            if (playerPos.y > pos.y)
            {
                if (speedy < speedCap)
                {

                    speedy = speedy + accel;
                }
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

        // adjust pos
        //Debug.Log("speedx: " + speedx);
        //Debug.Log("speedy: " + speedy);
        pos.y += speedy * Time.deltaTime;
        pos.x += speedx * Time.deltaTime;

        // move mob
        transform.position = pos;


        if (speedx < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }

    }

}
