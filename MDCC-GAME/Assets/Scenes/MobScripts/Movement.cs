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
    public float playerHp;
    Vector3 playerPos;
    public int coolDown = 0;
    public int coolDownTime = 200;

    private SpriteRenderer mySpriteRenderer;

    public List<GameObject> enemyArray;
    private bool closeToEnemiesX = false;
    public bool closeToEnemiesY = false;

    void Start()
    {
        //coolDown = coolDownTime;
        var playerZ = GameObject.Find("player");
        pHealth hpScript = playerZ.GetComponent<pHealth>();
        playerHp = hpScript.hp;


        // get enemy array
        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;


        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        accel = UnityEngine.Random.Range((accelStart * minSpeedPercent), (accelStart * maxSpeedPercent));
        //Debug.Log("accel: " + accel);
        //accelStart;//(rnd.Next((accelStart - 2), (accelStart + 2)));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // find player gameObj
        var playerZ = GameObject.Find("player");
        if (playerZ)
        {
            playerPos = playerZ.transform.position;
        }
        else
        {
            Debug.Log("Can't Find Player");
        }

        // get player health
        pHealth hpScript = playerZ.GetComponent<pHealth>();

        // find position
        Vector3 pos = transform.position;


        // find distances between mob and player
        float distanceX = Math.Abs(Math.Abs(playerPos.x) - Math.Abs(pos.x));
        float distanceY = Math.Abs(Math.Abs(playerPos.y) - Math.Abs(pos.y));
        //Debug.Log("Distance X from player: " + distanceX);
        //Debug.Log("Distance Y from player: " + distanceY);


        this.closeToEnemiesX = false;
        // NEEDS FIXING, NOT TRIGGERING
        foreach (GameObject o in enemyArray)
        {
            if (o.GetInstanceID() != gameObject.GetInstanceID())
            {
                Vector3 enemyPos = o.transform.position;
                float enemyDistanceX = Math.Abs(Math.Abs(enemyPos.x) - Math.Abs(pos.x));
                if (enemyDistanceX < .00001)
                {
                    
                    this.closeToEnemiesX = false;
                    Debug.Log("CloseToEnemiesX = " + this.closeToEnemiesX);
                }
            }
        }
       

        // if distance is less than
        if (distanceX > range)
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

        // attack player if in range
        coolDown += 1;
        if ((distanceX < range) && (distanceY < range))
        {           
            if (coolDown >= coolDownTime) 
            {
                Debug.Log("Attacked!");
                playerHp -= damage;
                coolDown = 0;
            }
        }
        //Debug.Log("Mob cooldown: " + coolDown);
        //Debug.Log("Health: " + playerHp);

        // adjust pos
        pos.y += speedy * Time.deltaTime;

        if (this.closeToEnemiesX == false)
        {
            pos.x += speedx * Time.deltaTime;
        } 

        // move mob
        transform.position = pos;

        // flip the sprite
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
