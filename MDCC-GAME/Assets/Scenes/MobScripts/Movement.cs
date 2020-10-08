using System.Collections;
using System.Collections.Generic;
using System;
//using System.Random;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float range = .5f;
    
    // movement stuff
    public float speedCap = 4f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public float accelStart = 1f;
    private float accel;

    public float maxSpeedPercent = 10.25f;
    public float minSpeedPercent = .005f;

    System.Random rnd = new System.Random();

    // attack stuff
    public int damage = 5;
    Vector3 playerPos;
    public int coolDown = 0;
    public int coolDownTime = 200;

    private SpriteRenderer mySpriteRenderer;

    public List<GameObject> enemyArray;
    private bool closeToEnemiesX = false;
    public bool closeToEnemiesY = false;

    // init player and script variables 
    GameObject p;
    pHealth ph;


    void Start()
    {
        // get player object and script
        p = GameObject.FindWithTag("Player");
        ph = p.GetComponent<pHealth>();

        // get enemy array
        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;


        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        accel = UnityEngine.Random.Range((accelStart * minSpeedPercent), (accelStart * maxSpeedPercent));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (p)
        {
            playerPos = p.transform.position;
        }
        else
        {
            Debug.Log("Can't Find Player");
        }

        // find position
        Vector3 pos = transform.position;


        // find distances between mob and player
        float distance = Vector3.Distance(playerPos, pos);//Math.Abs(Math.Abs(playerPos.x) - Math.Abs(pos.x));
        //float distanceY = Math.Abs(Math.Abs(playerPos.y) - Math.Abs(pos.y));
        //Debug.Log("Distance from player: " + distance);
     

        // if distance is greater than range

        
        if (distance > (range))
        {
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



        // attack player if in range
        coolDown += 1;
        if (distance < range)
        {           
            if (coolDown >= coolDownTime) 
            {
                if (ph.getHealth() > 0)
                {
                    ph.damagePlayer(damage);
                    coolDown = 0;
                }
                
            }
        }
        //Debug.Log("Mob cooldown: " + coolDown);

        // adjust pos
        pos.y += speedy * Time.deltaTime;
        pos.x += speedx * Time.deltaTime;
 
        // move mob
        transform.position = pos;

        // flip the sprite
        if (speedx < .3)
        {
            mySpriteRenderer.flipX = true;
        }
        if (speedx > .3)
        {
            mySpriteRenderer.flipX = false;
        }

        //Debug.Log("SpeedX: " + speedx);



    }

}
