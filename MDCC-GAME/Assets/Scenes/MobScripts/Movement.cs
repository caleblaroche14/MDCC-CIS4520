using System.Collections;
using System.Collections.Generic;
using System;
//using System.Random;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedCap = 10f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public int accelStart = 4;
    private int accel;
    public float haha = 1f;
    System.Random rnd = new System.Random();
    
    Vector3 playerPos;

    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        accel = (rnd.Next((accelStart - 2), (accelStart + 2)));

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
            Debug.Log("Found Player");
        }
        else
        {
            Debug.Log("Can't Find Player");
        }


        // go toward player

        // x axis

        float distanceX = Math.Abs(Math.Abs(playerPos.x) - Math.Abs(pos.x));
        float distanceY = Math.Abs(Math.Abs(playerPos.y) - Math.Abs(pos.y));
        Debug.Log("Distance X from player: " + distanceX);
        Debug.Log("Distance Y from player: " + distanceY);
        if (distanceX > .5)
        {
            if (pos.x < playerPos.x)
            {
                speedx = accel;
            }
            if (pos.x > playerPos.x)
            {
                speedx = -accel;
            }
        }
        else
        {
            speedx = 0;
        }

        // y axis
        if (distanceY > .5)
        {
            if (pos.y < playerPos.y)
            {
                speedy = accel;
            }
            if (pos.y > playerPos.y)
            {
                speedy = -accel;
            }
        }
        else
        {
            speedy = 0;
        }
        
        // adjust pos
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
